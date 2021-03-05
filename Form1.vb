Imports System.Globalization
Imports System.Threading

Public Class Form1
    Private Shared Dim current As CultureInfo = Thread.CurrentThread.CurrentUICulture
    Private Shared Dim currentLanguage As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CreateResouceManager("Bt1")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CreateResouceManager("Bt2")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CreateResouceManager("Bt3")
    End Sub

    Shared Sub Main()
        ChangeCulture("pt-BR")

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1)  'Specify the startup form
    End Sub

    Private Sub PORTUGUÊSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PORTUGUÊSToolStripMenuItem.Click
        ChangeCulture("")
        ReloadForms()
        Me.Hide()
    End Sub

    Private Sub INGLÊSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INGLÊSToolStripMenuItem.Click
        ChangeCulture("en-US")
        ReloadForms()
        Me.Hide()
    End Sub
    
    Private Sub ESPANHOLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ESPANHOLToolStripMenuItem.Click
        ChangeCulture("es-ES")
        ReloadForms()
        Me.Hide()
    End Sub

    Private Shared Sub ChangeCulture(ByVal language As String)
        If current.TwoLetterISOLanguageName <> language
            Dim newCulture As CultureInfo = CultureInfo.CreateSpecificCulture(language)
            Thread.CurrentThread.CurrentUICulture = newCulture
            ' Make current UI culture consistent with current culture.
            Thread.CurrentThread.CurrentCulture = newCulture
            currentLanguage = language
        End If
    End Sub

    Private Shared Sub ReloadForms()
        Dim form As New Form1()
        form.Show()
    End Sub

    Private Shared Sub CreateResouceManager(ByVal message As String)
            Dim ResMan As New Resources.ResourceManager("TesteRecursos.Messages", System.Reflection.Assembly.GetExecutingAssembly())
            MessageBox.Show(ResMan.GetString(message))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = DateTime.Now().ToString()
        SetColor()
        SetMainFlag()
        SetSubFlags()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        numOutput.Text = numInput.Text
    End Sub

    Private Sub SetColor()
        If currentLanguage = "pt-BR"
            TextBox1.ForeColor = Color.Green
        ElseIf currentLanguage = "en-US"
            TextBox1.ForeColor = Color.Blue
        ElseIf currentLanguage = "es-ES"
            TextBox1.ForeColor = Color.Orange
        End If
    End Sub

    Private Sub SetMainFlag()
        If currentLanguage = "pt-BR"
            ToolStripSplitButton1.Image = Image.FromFile("C:\Users\admin\source\repos\TesteRecursos\Resources\Img\Brazil_BR_BRA_076_Flag1_26109.png")
        ElseIf currentLanguage = "en-US"
            ToolStripSplitButton1.Image = Image.FromFile("C:\Users\admin\source\repos\TesteRecursos\Resources\Img\UnitedStates_US_USA_840_Flag1_26093.png")
        ElseIf currentLanguage = "es-ES"
            ToolStripSplitButton1.Image = Image.FromFile("C:\Users\admin\source\repos\TesteRecursos\Resources\Img\Spain_flags_flag_9119.png")
        End If
    End Sub

    Private Sub SetSubFlags()
        PORTUGUÊSToolStripMenuItem.Image = Image.FromFile("C:\Users\admin\source\repos\TesteRecursos\Resources\Img\Brazil_BR_BRA_076_Flag1_26109.png")
        INGLÊSToolStripMenuItem.Image = Image.FromFile("C:\Users\admin\source\repos\TesteRecursos\Resources\Img\UnitedStates_US_USA_840_Flag1_26093.png")
        ESPANHOLToolStripMenuItem.Image = Image.FromFile("C:\Users\admin\source\repos\TesteRecursos\Resources\Img\Spain_flags_flag_9119.png")

    End Sub

  
End Class
