'.---------------------------------------------------------------------------.
'|  Software: HTTP API - SMS Multiple Recipients SMS Example				 |
'|  Version: 	3.10														 |
'|  Email: 		support@solutions4mobiles.com								 |
'|  Info: 		http://www.solutions4mobiles.com							 |
'|  Phone:		+44 203 318 3618											 |
'| ------------------------------------------------------------------------- |
'| Copyright (c) 1999-2014, Mobiweb Ltd. All Rights Reserved.                |
'| ------------------------------------------------------------------------- |
'| LICENSE:																	 |
'| Distributed under the General Public License v3 (GPLv3)					 |
'| http://www.gnu.org/licenses/gpl-3.0.html									 |
'| This program is distributed AS IS and in the hope that it will be useful  |
'| WITHOUT ANY WARRANTY; without even the implied warranty of				 |
'| MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.                      |
'| ------------------------------------------------------------------------- |
'| SERVICES:																 |
'| We offer a number of paid services at http//www.solutions4mobiles.com:    |
'| - Bulk SMS / MMS / Premium SMS Services / HLR Lookup Service				 |
'| ------------------------------------------------------------------------- |
'| HELP:																	 |
'| - This class requires a valid HTTP API Account. Please email to			 |
'| sales@solutions4mobiles.com to get one									 |
''---------------------------------------------------------------------------'

' SMS Multiple Recipients SMS Example
' @copyright 1999 - 2014 Mobiweb Ltd.--%>

Imports System.Net
Imports System.IO

Module MultipleRecipientSMS

    Sub Main()
        Dim username As String
        username = "username"                                           ' The HTTP API username of your account. 
        Dim password As String
        password = "password"                                           ' The HTTP API password of your account.
        Dim msgtext As String
        msgtext = "Hello World"                                         ' The SMS Message text.
        Dim originator As String
        originator = "TestAccount"                                      ' The desired Originator of your message.
        Dim phone As String
        phone = "recipient1,recipient2"                                 ' The full International mobile number of the
        																' recipient excluding the leeding +.
        																' multiple recipients, separate each number with a 
        																' comma. Please note that no blanks can be used
        Dim showDLR As String
        showDLR = "0"                                                   ' Set to 1 for requesting delivery report 
        																' of this sms. A unique id is returned to use																								
        																' with your delivery report request.
        Dim smscharset As String
        smscharset = "0"                                                ' The SMS Message text Charset.
        Dim msgtype As String
        msgtype = ""                                                    ' If set to F the sms is sent as Flash.
        Dim smsprovider As String
        smsprovider = "solutions4mobiles.com"                           ' The SMS Provider.
        Dim url As String
        url = "http://IPADDRESS/send_script"							' The SMS HTTP API send url.
        Dim params As String                                            ' The parameter's string.
        params = "username=" + username + "&password=" + password + "&charset=" + smscharset + "&msgtext=" + msgtext + "&originator=" + originator + "&phone=" + phone + "&provider=" + smsprovider + "&showDLR=" + showDLR + "&msgtype=" + msgtype
        Dim sol4mob_request As WebRequest                               ' Create object of class required for POST request.
        sol4mob_request = WebRequest.Create(url)                        ' Initialize post object.
        With sol4mob_request
            .Method = "POST"
            .ContentType = "application/x-www-form-urlencoded"
        End With
        Dim requestStream As Stream                                     ' Create a request stream object for data to pass through.
        Dim requestStreamWriter As StreamWriter                         ' Create a request stream writer object for writing request data.

        requestStream = sol4mob_request.GetRequestStream()              ' Get writer
        requestStreamWriter = New StreamWriter(requestStream)
        requestStreamWriter.Write(params)                               ' Write parameters to POST request and send it.
        requestStreamWriter.Flush()                                     ' Flush and close objects.
        requestStreamWriter.Close()
        requestStream.Close()

        Dim sol4mob_response As WebResponse                             ' Create a response object to retrieve response.
        Dim responseStream As Stream                                    ' Create a response stream object for data to pass through.
        Dim responseStreamReader As StreamReader                        ' Create a response stream reader object for reading response data.

        sol4mob_response = sol4mob_request.GetResponse()                ' Get response and reader
        responseStream = sol4mob_response.GetResponseStream()
        responseStreamReader = New StreamReader(responseStream)         ' Print response
        Debug.WriteLine(responseStreamReader.ReadToEnd())
        responseStreamReader.Close()                                    ' Flush and close objects.
        responseStream.Close()
        sol4mob_response.Close()
    End Sub

End Module
