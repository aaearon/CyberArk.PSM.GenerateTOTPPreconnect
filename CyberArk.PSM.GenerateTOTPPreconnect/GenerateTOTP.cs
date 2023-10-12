using CyberArk.PSM.WebAppDispatcher.PreconnectUtils;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;

namespace CyberArk.PSM.GenerateTOTPPreconnect
{   
    
    public class GenerateTOTP : IPreconnectContract
    {
        private readonly string TOTP_OUTPUT_PARAMETER = "MFACode";

        public Dictionary<string, SecureString> GetParameters(Dictionary<string, SecureString> parameters, LogUtils.WriteToLogHandler writeToLogMethod)
        {
            Totp totp;

            try
            {
                writeToLogMethod("Generating TOTP.", Consts.LOG_LEVEL_INFO);
                totp = new Totp(Encoding.UTF8.GetBytes(new NetworkCredential(string.Empty, parameters["logonaccount_password"]).Password));
            }
            catch (KeyNotFoundException ex)
            {
                writeToLogMethod(string.Format("Key not found in parameters dictionary: {0}", ex.ToString()), Consts.LOG_LEVEL_ERROR);
                throw new PreconnectException("Key not found in parameters dictionary.");
            }
            catch (Exception ex)
            {
                writeToLogMethod(string.Format("Error while generating TOTP: {0}", ex.ToString()), Consts.LOG_LEVEL_ERROR);
                throw new PreconnectException("Error while generating TOTP.");
            }

            writeToLogMethod("Successfully generated TOTP.", Consts.LOG_LEVEL_INFO);

            return new Dictionary<string, SecureString> {
                {
                    TOTP_OUTPUT_PARAMETER,
                    new NetworkCredential(string.Empty, totp.ComputeTotp()).SecurePassword
                }
            };
        }
    }
}
