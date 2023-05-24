Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports System.Drawing.Printing
Imports DevExpress.XtraPrintingLinks
Imports System.Drawing.Imaging
Imports DevExpress.Drawing.Printing

Namespace PrintImageFrames

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            ReportAnImage(Application.StartupPath & "\..\..\" & "Rotating_earth_(small).gif", checkBox1.Checked)
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            ReportAnImage(Application.StartupPath & "\..\..\" & "Prices.tiff", checkBox1.Checked)
        End Sub

        Private Sub ReportAnImage(ByVal filename As String, ByVal pageBreakAfterEachImage As Boolean)
            Dim compositeLink As CompositeLink = New CompositeLink(printingSystem1)
            Dim image As Image = Image.FromFile(filename)
            Dim frameDimension As FrameDimension = New FrameDimension(image.FrameDimensionsList(0))
            Dim framesCount As Integer = image.GetFrameCount(frameDimension)
            For i As Integer = 0 To framesCount - 1
                image.SelectActiveFrame(frameDimension, i)
                compositeLink.Links.Add(New ImageLink(New Bitmap(image), pageBreakAfterEachImage))
            Next

            image.Dispose()
            compositeLink.PaperKind = DXPaperKind.A3
            compositeLink.Landscape = True
            compositeLink.ShowPreviewDialog()
        End Sub
    End Class

    Public Class ImageLink
        Inherits Link

        Private imageField As Image

        Public Property Image As Image
            Get
                Return imageField
            End Get

            Set(ByVal value As Image)
                imageField = value
            End Set
        End Property

        Private addPageBreakField As Boolean

        Public Property AddPageBreak As Boolean
            Get
                Return addPageBreakField
            End Get

            Set(ByVal value As Boolean)
                addPageBreakField = value
            End Set
        End Property

        Public Sub New()
            Me.New(Nothing, Nothing, False)
        End Sub

        Public Sub New(ByVal image As Image, ByVal addPageBreak As Boolean)
            Me.New(Nothing, image, addPageBreak)
        End Sub

        Public Sub New(ByVal ps As PrintingSystem, ByVal image As Image, ByVal addPageBreak As Boolean)
            MyBase.New(ps)
            Me.Image = image
            Me.AddPageBreak = addPageBreak
        End Sub

        Protected Overrides Sub CreateDetail(ByVal graph As BrickGraphics)
            If Image IsNot Nothing Then
                ' Add an image to a specific location.
                graph.DrawImage(Image, New Rectangle(0, 0, Image.Width, Image.Height), BorderSide.None, Color.Transparent)
                ' Add a page break after the image.
                If AddPageBreak Then graph.PrintingSystem.InsertPageBreak(Image.Height + 1)
            End If
        End Sub
    End Class
End Namespace
