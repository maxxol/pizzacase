using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace pizzacase
{
    class InternetClient
    {
        private static InternetClient internetClientSingleton;

        private InternetClient() { }

        public static InternetClient getInstance() 
        {
            if (internetClientSingleton == null)
                internetClientSingleton = new InternetClient();
            return internetClientSingleton;
        }
        
        public void sendData(string protocol, string data, string privateKey)
        {
            switch (protocol)
            {
                case "UDP":
                    sendDataUDP(data, privateKey);
                    break;
                case "TCP":
                    sendDataTCP(data, privateKey);
                    break;
            }
        }
        private void sendDataUDP(string data, string privateKey)
        {
            var udp = new UdpClient();

            string encryptedData = DataEncryptor.EncryptData(data, privateKey);
            byte[] encryptedDataBytes = Encoding.ASCII.GetBytes(encryptedData);

            udp.Send(encryptedDataBytes, encryptedData.Length, IPAddress.Loopback.ToString(), 5000);
        }
        private void sendDataTCP(string data, string privateKey)
        {
            using var client = new TcpClient(IPAddress.Loopback.ToString(), 5000);
            using var stream = client.GetStream();

            // Encrypt → Base64 string
            string encryptedBase64 = DataEncryptor.EncryptData(data, privateKey);

            // Convert Base64 text to bytes (UTF-8)
            byte[] payload = Encoding.UTF8.GetBytes(encryptedBase64);

            // Add 4-byte length prefix
            byte[] lengthPrefix = BitConverter.GetBytes(payload.Length);

            // Send [length][payload]
            stream.Write(lengthPrefix, 0, lengthPrefix.Length);
            stream.Write(payload, 0, payload.Length);
            stream.Flush();
        }

    }
}
