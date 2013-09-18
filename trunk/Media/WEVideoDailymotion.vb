Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.IO
Imports System.Web.UI

Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Editors.Converter
Imports openElement.WebElement.Elements

Imports WebElement.Elements.Media.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Media

    <Serializable> _
    Public Class WEVideoDailymotion
        Inherits ElementBase

        #Region "Fields"

        Private _DailymotionURL As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEVideoDailymotion", page, parentID, templateName)
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        '<Category("Edition"), _
        'DisplayName("URL"), _
        'Description("URL de la vidéo Dailymotion" & vbCrLf & ""), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N019"), _
        LocalizableDescAtt("_D032"), _
        Editor(GetType(UITypeDailymotion), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property DailymotionURL() As LocalizableString
            Get
                If _DailymotionURL Is Nothing Then _DailymotionURL = New LocalizableString
                Return _DailymotionURL
            End Get
            Set(ByVal value As LocalizableString)
                _DailymotionURL = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0066 ' "Vidéo Dailymotion"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WEVideo
            info.ToolBoxDescription = LocalizableOpen._0067 '"Ajouter une vidéo Dailymotion"
            info.AutoOpenProperty = "DailymotionURL"
            info.SortPropertyList.Add(New SortProperty("DailymotionURL", "movie.png", LocalizableOpen._0058)) '"Sélection de l'URL."
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Dim url As String
            If String.Compare(Me.Page.Culture, "DEFAULT") Then
                url = DailymotionURL.GetValue()
            Else
                url = DailymotionURL.GetValue(Me.Page.Culture)
            End If

            If Not (String.IsNullOrEmpty(url) Or MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor) Then
                Dim script As String = DailymotionURL.GetValue(Me.Page.Culture)

                If script.StartsWith("http://") Then
                    'ancienne methode dailymotion (permalink)

                    writer.WriteBeginTag("object")
                    writer.WriteAttribute("width", "100%")
                    writer.WriteAttribute("height", "100%")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteLine()

                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "movie")
                    writer.WriteAttribute("value", url)
                    writer.Write(HtmlTextWriter.SelfClosingTagEnd)
                    writer.WriteLine()

                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "allowFullScreen")
                    writer.WriteAttribute("value", "true")
                    writer.Write(HtmlTextWriter.SelfClosingTagEnd)
                    writer.WriteLine()

                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "allowscriptaccess")
                    writer.WriteAttribute("value", "always")
                    writer.Write(HtmlTextWriter.SelfClosingTagEnd)
                    writer.WriteLine()

                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "wmode")
                    writer.WriteAttribute("value", "transparent")
                    writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                    writer.WriteBeginTag("embed")
                    writer.WriteAttribute("type", "application/x-shockwave-flash")
                    writer.WriteAttribute("src", url)
                    writer.WriteAttribute("width", "100%")
                    writer.WriteAttribute("height", "100%")
                    writer.WriteAttribute("allowscriptaccess", "always")
                    writer.WriteAttribute("allowfullscreen", "true")
                    writer.WriteAttribute("wmode", "transparent")
                    writer.WriteEndTag("embed")
                    writer.WriteLine()
                    writer.WriteEndTag("object")
                Else
                    'nouvelle version
                    writer.Write(script)
                End If

            Else

                'Affichage Si aucun fichier selectionné et dans l'editeur
                writer.WriteBeginTag("table")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", Path.Combine(Utils.EditorModCSSPath, "images/movieDailymotion.png"))
                writer.WriteAttribute("alt", "")
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")

            End If

            MyBase.RenderEndTag(writer)
        End Sub

        #End Region 'Methods

    End Class

End Namespace

