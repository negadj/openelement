Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements

Imports WebElement.Elements.Interactivity.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Interactivity

    <Serializable> _
    Public Class WEPayPal
        Inherits ElementBase

        #Region "Fields"

        Private _Script As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEPayPal", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N193"), _
        LocalizableDescAtt("_D193"), _
        Editor(GetType(UITypePayPal), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Script() As LocalizableString
            Get
                If _Script Is Nothing Then _Script = New LocalizableString
                Return _Script
            End Get
            Set(ByVal value As LocalizableString)
                _Script = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = "PayPal"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupInteractivity"
            info.ToolBoxIco = My.Resources.WEPayPal
            info.ToolBoxDescription = LocalizableOpen._0310
            info.AutoOpenProperty = "Script"
            info.SortPropertyList.Add(New SortProperty("Script", "Tools.png", LocalizableOpen._0206))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)
            Dim scriptLang As String = Script.GetValue(Me.Page.Culture)

            If Not String.IsNullOrEmpty(scriptLang) Then
                writer.Write(scriptLang)
            Else
                writer.WriteBeginTag("table")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.Write(LocalizableOpen._0307)

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")

            End If

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

