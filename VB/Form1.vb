Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports System.Drawing.Printing
Imports DevExpress.XtraPrintingLinks
Imports System.Drawing.Imaging
Imports System.IO

Namespace PrintImageFrames
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			ReportAnImage(Application.StartupPath & "\..\..\" & "Rotating_earth_(small).gif", checkBox1.Checked)
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			ReportAnImage(Application.StartupPath & "\..\..\" & "Prices.tiff", checkBox1.Checked)
		End Sub

		Private Sub ReportAnImage(ByVal filename As String, ByVal pageBreakAfterEachImage As Boolean)
			Dim compositeLink As New CompositeLink(printingSystem1)
			Dim image As Image = Image.FromFile(filename)
			Dim frameDimension As New FrameDimension(image.FrameDimensionsList(0))
			Dim framesCount As Integer = image.GetFrameCount(frameDimension)

			For i As Integer = 0 To framesCount - 1
				image.SelectActiveFrame(frameDimension, i)
				compositeLink.Links.Add(New ImageLink(New Bitmap(image), pageBreakAfterEachImage))
			Next i

			image.Dispose()

			compositeLink.PaperKind = PaperKind.A3
			compositeLink.Landscape = True

			compositeLink.ShowPreviewDialog()
		End Sub

	End Class

	Public Class ImageLink
		Inherits Link

		Private image_Renamed As Image

		Public Property Image() As Image
			Get
				Return image_Renamed
			End Get
			Set(ByVal value As Image)
				image_Renamed = value
			End Set
		End Property

		Private addPageBreak_Renamed As Boolean

		Public Property AddPageBreak() As Boolean
			Get
				Return addPageBreak_Renamed
			End Get
			Set(ByVal value As Boolean)
				addPageBreak_Renamed = value
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

				If AddPageBreak Then
					' Add a page break after the image.
					graph.PrintingSystem.InsertPageBreak(Image.Height + 1)
				End If
			End If
		End Sub

	End Class

End Namespace
