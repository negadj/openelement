Imports System.ComponentModel
Imports System.Drawing
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
    Public Class WEVideoYouTube
        Inherits ElementBase

        #Region "Fields"

        Private _Border As Boolean
        Private _DarkColor As Color
        Private _LightColor As Color
        Private _YouTubeURL As LocalizableString

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEVideoYouTube", page, parentID, templateName)

            'paramètrage par défaut  (boolean et integer)
            Border = False
            LightColor = ColorTranslator.FromHtml("#EFEFEF")
            DarkColor = ColorTranslator.FromHtml("#666666")
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        '   <Category("Apparence"), _
        'DisplayName("Bordure"), _
        'Description("Affichage de la bordure" & vbCrLf & "")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N022"), _
        LocalizableDescAtt("_D022")> _
        Public Property Border() As Boolean
            Get
                Return _Border
            End Get
            Set(ByVal value As Boolean)
                _Border = value
            End Set
        End Property

        '    <Category("Apparence"), _
        'DisplayName("Couleur foncée"), _
        'Description("Couleur foncée du lecteur et de la bordure" & vbCrLf & "")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N021"), _
        LocalizableDescAtt("_D021")> _
        Public Property DarkColor() As Color
            Get
                Return _DarkColor
            End Get
            Set(ByVal value As Color)
                _DarkColor = value
            End Set
        End Property

        '<Category("Apparence"), _
        'DisplayName("Couleur clair"), _
        'Description("Couleur clair du lecteur et de la bordure" & vbCrLf & "")> _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N020"), _
        LocalizableDescAtt("_D020")> _
        Public Property LightColor() As Color
            Get
                Return _LightColor
            End Get
            Set(ByVal value As Color)
                _LightColor = value
            End Set
        End Property

        '<Category("Edition"), _
        'DisplayName("URL"), _
        'Description("URL de la vidéo YouTube" & vbCrLf & ""), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N019"), _
        LocalizableDescAtt("_D019"), _
        Editor(GetType(UITypeYouTube), GetType(UITypeEditor)), _
        TypeConverter(GetType(TConvLocalizableString)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.None)> _
        Public Property YouTubeURL() As LocalizableString
            Get
                If _YouTubeURL Is Nothing Then _YouTubeURL = New LocalizableString
                Return _YouTubeURL
            End Get
            Set(ByVal value As LocalizableString)
                _YouTubeURL = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0056 ' "Vidéo YouTube"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WEVideo
            info.ToolBoxDescription = LocalizableOpen._0057 '"Ajouter une vidéo YouTube."
            info.AutoOpenProperty = "YouTubeURL"
            info.SortPropertyList.Add(New SortProperty("YouTubeURL", "movie.png", LocalizableOpen._0058)) '"Sélection du l'URL"
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            MyBase.OnOpen()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            Dim url As String
            If String.Compare(Me.Page.Culture, "DEFAULT") Then
                url = YouTubeURL.GetValue()
            Else
                url = YouTubeURL.GetValue(Me.Page.Culture)
            End If

            If Not (String.IsNullOrEmpty(url) Or MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor) Then

                If Not LightColor.IsEmpty Then

                    url = String.Concat(url, "&color1=", ColorTranslator.ToHtml(LightColor).Replace("#", "0x"))
                End If
                If Not DarkColor.IsEmpty Then
                    url = String.Concat(url, "&color2=", ColorTranslator.ToHtml(DarkColor).Replace("#", "0x"))
                End If

                If Border Then url = String.Concat(url, "&border=1")

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

                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", "wmode")
                writer.WriteAttribute("value", "transparent")
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteLine()

                writer.WriteBeginTag("embed")
                writer.WriteAttribute("type", "application/x-shockwave-flash")
                writer.WriteAttribute("src", url)
                writer.WriteAttribute("width", "100%")
                writer.WriteAttribute("height", "100%")
                writer.WriteAttribute("allowscriptaccess", "always")
                writer.WriteAttribute("allowfullscreen", "true")
                writer.WriteAttribute("wmode", "transparent")
                writer.Write(HtmlTextWriter.SelfClosingTagEnd)
                writer.WriteEndTag("embed")
                writer.WriteLine()
                writer.WriteEndTag("object")

                'MyBase.StylesSkin .FindStylesZone("").BaseStyles. 'Appel d'un style dans le render

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
                writer.WriteAttribute("src", Path.Combine(Utils.EditorModCSSPath, "images/movieYouTube.png"))
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

