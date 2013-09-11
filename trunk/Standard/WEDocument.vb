Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.DataType

Namespace WEElements.Standard


    <Serializable()> _
    Public Class WEDocument
        Inherits ElementBase

#Region "Properties"

        Private _HTML As HtmlBlock

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N122"), _
        Ressource.localizable.LocalizableDescAtt("_D122"), _
        Editor(GetType(Editors.UITypeHTML), GetType(Drawing.Design.UITypeEditor))> _
       Public Property HTML() As HtmlBlock
            Get
                If _HTML Is Nothing Then _HTML = New HtmlBlock
                Return _HTML
            End Get
            Set(ByVal value As HtmlBlock)
                _HTML = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEDocument", page, parentID, templateName)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0137
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupOther"
            info.ToolBoxIco = My.Resources.WEDocument
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0138
            info.AutoOpenProperty = "HTML"
            info.SortPropertyList.Add(New SortProperty("HTML", "edit.png", My.Resources.text.LocalizableOpen._0139))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.OnOpen()
        End Sub

#End Region

#Region "Render"


        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)
            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then

                writer.WriteBeginTag("div")
                writer.WriteAttribute("style", String.Concat("width:100%;height:100%;background-image: url(file:///", openElement.Tools.Path.IOSitePath("/WEFiles/Image/mask.png"), ")"))
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                writer.Write(Me.HTML.Html.GetValue(Me.Page.Culture))
                writer.WriteEndTag("div")
            Else
                writer.Write(Me.HTML.Html.GetValue(Me.Page.Culture))
            End If
            MyBase.RenderEndTag(writer)

        End Sub

#End Region

    End Class
End Namespace