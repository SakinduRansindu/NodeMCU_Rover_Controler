#include <Servo.h>
#include<ESP8266WiFi.h>


const char* ssid = "Your Router SSID";
const char* password = "WiFi Password";

#define RF D0
#define RB D1
#define LF D3
#define LB D2
#define LED_R D8
#define LED_G D7
#define LED_B D6
#define H_Axis_Servo D5
#define V_Axis_Servo D4


const int lo = 0;
const int firstGear = 150;
const int secondGear = 200;
const int thirdGear = 255;
const int max_H_Rotation = 170;
const int min_H_Rotation = 0;
const int max_V_Rotation = 170;
const int min_V_Rotation = 0;

int gear = firstGear;

const int REFRESH_RATE = 500; //set refresh rate to 0.5S.
const int REFRESH_RATE_AFTER_CLIENT = 2;
const int PROTECTION_CMD_EXE_RATE = 500;
const int PORT = 5599;


WiFiServer server(PORT);
Servo Hservo;
Servo Vservo;

int H_rotation = 90;
int V_rotation = 90;
long clk = 0;
void(* resetFunc) (void) = 0;

void setup() {
  Hservo.attach(H_Axis_Servo);
  Vservo.attach(V_Axis_Servo);
  Hservo.write(H_rotation);
  Vservo.write(V_rotation);
  pinMode(LED_R,OUTPUT);
  pinMode(LED_G,OUTPUT);
  pinMode(LED_B,OUTPUT);
  RGB_LED(255,0,0);
  Serial.begin(115200);
  Serial.print("Connecting");
  WiFi.begin(ssid, password);
  
  while (WiFi.status() != WL_CONNECTED) {
    RGB_LED(0,0,0);
    delay(500);
    RGB_LED(255,0,0);
    delay(500);
    Serial.print(".");
  }
  RGB_LED(0,255,0);
  Serial.println("\nConnected");
  Serial.print("IP ADDRESS :");
  Serial.println(WiFi.localIP());
  server.begin();
  Serial.println("server started.");

  pinMode(RF,OUTPUT);
  pinMode(RB,OUTPUT);
  pinMode(LF,OUTPUT);
  pinMode(LB,OUTPUT);
  
  roverStop();
  Serial.println("rover is ready.");
}

void loop() {
  //run recursivly on predefinded time period
  if (clk <= millis()) {
      LED_Toggle();
    if (WiFi.status() != WL_CONNECTED) { //disconnected
      Serial.println("Connection lost :(");
      Serial.println("Resetting...");
      RGB_LED(255,0,0);
      resetFunc();
    }
    else { //no problem in connection
      WiFiClient client_ = server.available();
      //Serial.println("waiting for clients.");
      if (client_){
        Serial.println("Client Connected.");
        RGB_LED(250,0,250);
        StattingWorkWithClient(client_);
      }
    }

    clk = millis() + REFRESH_RATE;
  }

  //check Serial commands are available
  checkSerialCmds();

}

bool tgl = true;
void LED_Toggle()
{
  if(tgl){
    tgl = false;
    RGB_LED(0,255,0);
    }
  else{
    tgl = true;
    RGB_LED(0,0,0);
    }
  }

void RGB_LED(int R,int G,int B)
{
    analogWrite(LED_R,R);
    analogWrite(LED_G,G);
    analogWrite(LED_B,B);
  }

void setGear(int g){
    if(g==1){
      gear = firstGear;
      }
    else if(g==2){
      gear = secondGear;
      }
    else if(g==3){
      gear = thirdGear;
      }
  }

int lastCmd = 0;
long cmdTimeOut = 0;

void roverStop(){
  analogWrite(RF,lo);
  analogWrite(RB,lo);
  analogWrite(LF,lo);
  analogWrite(LB,lo);
  lastCmd = 1;
  cmdTimeOut = millis();
  }

 void roverTurnRight(){
  analogWrite(RF,lo);
  analogWrite(RB,gear);
  analogWrite(LF,gear);
  analogWrite(LB,lo);
  lastCmd = 2;
  cmdTimeOut = millis();

  } 

void roverTurnLeft(){
  analogWrite(RF,gear);
  analogWrite(RB,lo);
  analogWrite(LF,lo);
  analogWrite(LB,gear);
  lastCmd = 3;
  cmdTimeOut = millis();

  }

void roverForward(){
  analogWrite(RF,gear);
  analogWrite(RB,lo);
  analogWrite(LF,gear);
  analogWrite(LB,lo);
  lastCmd = 4;
  cmdTimeOut = millis();

  }

void roverBackward(){
  analogWrite(RF,lo);
  analogWrite(RB,gear);
  analogWrite(LF,lo);
  analogWrite(LB,gear);
  lastCmd=5;
  cmdTimeOut = millis();
  }


const int servoSpeed = 5;
void camUp(){
  if(H_rotation+servoSpeed<=max_H_Rotation){
    H_rotation+=servoSpeed;
    Hservo.write(H_rotation);
  }
}
void camDown(){
  if(H_rotation-servoSpeed>=min_H_Rotation){
    H_rotation-=servoSpeed;
    Hservo.write(H_rotation);
  }
}
void camLeft(){
    if(V_rotation-servoSpeed>=min_V_Rotation){
    V_rotation-=servoSpeed;
    Vservo.write(V_rotation);
  }
}
void camRight(){
  if(V_rotation+servoSpeed<=max_V_Rotation){
    V_rotation+=servoSpeed;
    Vservo.write(V_rotation);
  }
}

void checkSerialCmds(){
    String cmd;
  while (Serial.available() > 0) {
    cmd += Serial.readString();
  }
  if (cmd.length() > 0) {
    String cmdE = "";
    for (int i = 0; i < cmd.length(); i++) {
      if (cmd[i] != '\n') {
        cmdE += cmd[i];
      }
      else {
        execute_cmd(cmdE);
        cmdE = "";
      }
    }
  }
  }

bool isConnectedWithClient = false;
String msgToSend;
bool waitingForSendingMsg = false;
void execute_cmd(String cmd)
{
  Serial.print("executing command :");
  Serial.println(cmd);
  cmd.trim();
  if (cmd == "reset") {
    Serial.println("resetting");
    resetFunc();
  }
  
  if(isConnectedWithClient){//execute these commands only if Client connected
    if(cmd.startsWith("send=")){
      msgToSend = cmd.substring(5);
      Serial.println("sending msg :"+msgToSend);
      waitingForSendingMsg = true;
      }  
    }
}

void StattingWorkWithClient(WiFiClient client_) {
  while (WiFi.status() == WL_CONNECTED && client_.connected() ) {
    if(clk <= millis()){
      isConnectedWithClient = true;
      if(waitingForSendingMsg){
      client_.println(msgToSend);
      waitingForSendingMsg = false;
      }
      //Serial.println("client is online");
      checkSerialCmds();
      if(client_.available()){
          String line = client_.readStringUntil('\n');
          Serial.println(line);
             if (line == "reset") {
              Serial.println("resetting");
              resetFunc();
              }
            if(line == "RoverStop"){
                roverStop();
              }
            else if(line=="RoverF"){
                roverForward();
              }
            else if(line=="RoverB"){
                roverBackward();
              }
            else if(line=="RoverR"){
                roverTurnRight();
              }
            else if(line=="RoverL"){
                roverTurnLeft();
              }
            else if(line=="CamU"){
              camUp();
            }
            else if(line=="CamD"){
              camDown();
            }
            else if(line=="CamL"){
              camLeft();
            }
            else if(line=="CamR"){
              camRight();              
            }            
            if(line.startsWith("Gear=")){
                String temGear = line.substring(5);
                int tGear = temGear.toInt();
                setGear(tGear);
                executeLastCmd();
              }
        }
      clk = millis() + REFRESH_RATE_AFTER_CLIENT;
    }
    if(cmdTimeOut+PROTECTION_CMD_EXE_RATE <= millis())
       {
       roverStop();
       Serial.println("executing roverStop signal for rover protection.");
       }
    }
    roverStop();
    Serial.println("Client disconnected");
    isConnectedWithClient = false;
  }

  void executeLastCmd()
  {
      if(lastCmd==1){roverStop();}
      else if(lastCmd==2){roverTurnRight();}
      else if(lastCmd==3){roverTurnLeft();}
      else if(lastCmd==4){roverForward();}
      else if(lastCmd==5){roverBackward();}

    }
