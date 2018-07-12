/*
 * Dieser Code verwendet den ESP8266 Core (https://github.com/esp8266/Arduino)
 * und die PubSubClient Library (https://github.com/knolleary/pubsubclient)
 * 
 * Basiert auf dem MQTT Example der PubSubClient Library und enthält
 * daher einen Großteil an unverändertem Originalcode aus diesem Beispiel
*/

#include <ESP8266WiFi.h>
#include <PubSubClient.h>

const char* ssid = "GameRoom"; // Name des WLANs
const char* password = "p6gamer00m"; // Passwort des WLANs
const char* mqtt_server = "192.168.178.23"; // IP des MQTT Brokers

// Leben (HIGH = an / LOW = aus)
int elTop = 5; // Erster Anschluss (v.l.) — Pin D1
int elMid = 4; // Zweiter Anschluss (v.l.) — Pin D2
int elBot = 12; // Dritter Anschluss (v.l.) — Pin D6

// Vibration (LOW = an / HIGH = aus)
int vib = 13; // Pin D7

// Lebenszähler
int life = 3;

WiFiClient espClient;
PubSubClient client(espClient);

void setup() {
  Serial.begin(115200);
  
  setup_wifi();
  
  client.setServer(mqtt_server, 1883);
  client.setCallback(callback);

  pinMode(elTop, OUTPUT);
  pinMode(elMid, OUTPUT);
  pinMode(elBot, OUTPUT);

  pinMode(vib, OUTPUT);
  digitalWrite(vib, HIGH);

  start();
}

// Kurze Startanimation der 3 Lebenswires
void start() {
  digitalWrite(elBot, HIGH);
  delay(800);
  digitalWrite(elMid, HIGH);
  delay(800);
  digitalWrite(elTop, HIGH);
}

// Originalcode aus Example
void setup_wifi() {
  delay(10);
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}

// Originalcode aus Example (bis auf den Switch)
void callback(char* topic, byte* payload, unsigned int length) {  
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  for (int i = 0; i < length; i++) {
    Serial.print((char)payload[i]);
  }
  Serial.println();

  char message = (char)payload[0];

  /* 
   * Case 0: (Re-)Start des Spiels
   * Case 1: Treffer, man verliert ein Leben
   * Case 2: Lifegain, man erhält ein Leben
   */
  switch (message) {
    case '2':
      if (life == 1) {
        life = 2;
        gain(elMid);
      } else if (life == 2) {
        life = 3;
        gain(elTop);
      }
      break;
      
    case '1':
      if (life == 3) {
        life = 2;
        hit(elTop);
      } else if (life == 2) {
        life = 1;
        hit(elMid);
      } else if (life == 1) {
        life = 0;
        hit(elBot);
      }
      break;
      
    case '0':
      life = 3;
      start();
      break;
      
    default:
      break;
  } 
}

// Vibration + Erlischen eines Wires bei Treffer
void hit(int pin) {
  digitalWrite(pin, LOW);
  digitalWrite(vib, LOW);
  delay(700);
  digitalWrite(vib, HIGH);
}

// Vibrationsmuster bei Aufsammeln von Leben
void gain(int pin) {
  digitalWrite(pin, HIGH);
  digitalWrite(vib, LOW);
  delay(400);
  digitalWrite(vib, HIGH);
  delay(200);
  digitalWrite(vib, LOW);
  delay(400);
  digitalWrite(vib, HIGH);
}

// Originalcode aus Example
void reconnect() {
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    if (client.connect("p6weste")) {
      Serial.println("connected");
      client.subscribe("weste");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      delay(5000);
    }
  }
}

void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop();
}
