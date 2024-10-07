#include <SPI.h>
#include <printf.h>
#include <RF24.h>

#define CE_PIN  7
#define CSN_PIN 8

#define PAYLOAD_LENGHT 200

RF24 radio(CE_PIN, CSN_PIN);

const uint8_t address[][6] = { "1Node", "2Node", "3Node", "4Node", "5Node", "6Node" };

uint8_t nodeID = 0;

struct PayloadStruct
{
  char message[PAYLOAD_LENGHT];
  uint8_t counter;
};

PayloadStruct payload;

void setup() {
  Serial.begin(115200);

  Serial.println("Please choose the node you desire to ocupy (0-5):");
  while(Serial.available() == 0){}

  String input = Serial.readStringUntil('\n');
  int inputID = input.toInt();
  
  nodeID = inputID;
  
  Serial.println("Assigning node " + String(nodeID));

  radio.begin();
  radio.setChannel(76);
  radio.setPALevel(RF24_PA_HIGH);
  radio.setDataRate(RF24_1MBPS);
  radio.setCRCLength(RF24_CRC_16);

  radio.openWritingPipe(address[nodeID]);
  radio.openReadingPipe(1, address[nodeID]);
  payload.counter = 0;

  radio.startListening(); // Start listening for incoming messages
}

void loop() {

  if (radio.available()) // Check if there is a message available
  {
    memset(&payload, 0, sizeof(payload));
    radio.read(&payload, sizeof(payload)); // Read the incoming payload

    // Parse the incoming message
    int transmitterNode, receiverNode;
    char customMessage[100]; // Buffer for custom message

    // Extract the message format "{TransmitterNode} {ReceiverNode} {CustomMessage}"
    if (sscanf(payload.message, "%d %d %[^\n]", &transmitterNode, &receiverNode, customMessage) == 3)
    {
      // Check if the message is meant for this node
      if (receiverNode == nodeID)
      {
        // Print the received message details
        // Serial.print("Received message: ");
        Serial.println(payload.message);
      }
      else
      {
        Serial.print("Message ignored | Inteded Node: ");
        Serial.println(receiverNode); // Print the ignored message for clarity
      }
    }
    else
    {
      Serial.println("Invalid message format received.");
    }
  }
  
  if (Serial.available()) // Check if there's input from the Serial Monitor
  {
    radio.stopListening(); // Stop listening for incoming messages

    String input_monitor = Serial.readString();

    input_monitor[PAYLOAD_LENGHT-1] = '\n';

    // Read the input into a buffer
    char inputMessage[PAYLOAD_LENGHT]; // Adjust size as needed

    input_monitor.toCharArray(inputMessage, sizeof(inputMessage));

    // Parse the receiver node and custom message
    int receiverNode;
    char customMessage[PAYLOAD_LENGHT]; // Adjust size as needed

    // Use sscanf to extract receiver node and message from input
    if (sscanf(inputMessage, "%d %[^\n]", &receiverNode, customMessage) == 2)
    {
      // Prepare the message to send
      payload.counter++; // Increment the counter

      // Loop through all nodes to send the message
      for (uint8_t i = 0; i < sizeof(address) / sizeof(address[0]); i++)
      {
        // Format the message as "{TransmitterNode} {ReceiverNode} {CustomMessage}"
        snprintf(payload.message, sizeof(payload.message), "%d %d %s", nodeID, receiverNode, customMessage);
        radio.openWritingPipe(address[i]); // Open the pipe to the specific receiver

        // Send the payload
        bool success = radio.write(&payload, sizeof(payload)); 

        if (success)
        {
          Serial.print("Message sent to Node ");
          Serial.println(i);
        }
        else
        {
          Serial.print("Failed to send to Node ");
          Serial.println(i);
        }
        delay(100); // Small delay to avoid flooding
      }
    }
    else
    {
      Serial.println("Invalid input format. Please use: {ReceiverNode} {CustomMessage}");
    }
    radio.startListening();
    delay(2000); // Wait before allowing another input
  }
}


