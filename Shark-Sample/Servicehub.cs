using System.Net;
using Shark.Networking;
using SharkSample.DataContracts;

namespace SharkSample
{
    class ServiceHub
    {
        static readonly IPEndPoint TEST_ENV = new IPEndPoint(IPAddress.Parse("112.78.10.87"), 2813);
        static readonly string TEST_CRED = "AAAAwWSFDlY:APA91bEEPO82XbxZYKFbORCqr_uRXiMYJt_55m_HUrp7meKhol5OTnT5t3vs4qzts6db3vlmO_twiGErIM9poIb9S5sXIzvZPNwZAJa1wBTb_pF0Ncb3APw-4Sdq8INM5wWUAmw95cA3";

        public static Shark.Networking.CommunicationResults Request<TData, TReturn>(string serviceName, TData data, out TReturn result)
        {
            RequestData<TData> reqData = new RequestData<TData>(TEST_CRED, CredentialTypes.Unknown, data);
            ResponseData<TReturn> response;
            Shark.Networking.CommunicationResults state = Communicator.Request(TEST_ENV, serviceName, reqData, out response);
            if (response == null) { result = default(TReturn); return Shark.Networking.CommunicationResults.Unknown; }

            if (state == Shark.Networking.CommunicationResults.OK)
            {
                switch (response.Result)
                {
                    case DataContracts.CommunicationResults.InvalidCredential:
                        result = default(TReturn);
                        return Shark.Networking.CommunicationResults.NotProcessed;

                    case DataContracts.CommunicationResults.NotPermitted:
                        result = default(TReturn);
                        return Shark.Networking.CommunicationResults.NotProcessed;

                    case DataContracts.CommunicationResults.InvalidRequest:
                        result = default(TReturn);
                        return Shark.Networking.CommunicationResults.MalformedRequestData;

                    case DataContracts.CommunicationResults.OK:
                        result = response.Data;
                        return Shark.Networking.CommunicationResults.OK;

                    default:
                        result = default(TReturn);
                        return Shark.Networking.CommunicationResults.Unknown;
                }
            }

            result = default(TReturn);
            return state;
        }
    }
}
