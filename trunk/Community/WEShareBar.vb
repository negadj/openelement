Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Web.UI

Imports openElement.Tools
Imports openElement.WebElement
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Elements
Imports openElement.WebElement.ElementWECommon.Community.Forms
Imports openElement.WebElement.StylesManager

Imports WebElement.Elements.Community.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Community

    <Serializable> _
    Public Class WEShareBar
        Inherits ElementBase

        #Region "Fields"

        ''' <summary>
        ''' behavior Share bar config  
        ''' </summary>
        ''' <remarks></remarks>
        Private _Config As FrmShareBar.ConfigShareBar

        ''' <summary>
        ''' twitter follow script
        ''' </summary>
        ''' <remarks></remarks>
        Private _FollowScript As String

        ''' <summary>
        ''' Google plus script
        ''' </summary>
        ''' <remarks></remarks>
        Private _GPlusScript As String

        ''' <summary>
        ''' Facebook like script
        ''' </summary>
        ''' <remarks></remarks>
        Private _LikeScript As String

        ''' <summary>
        ''' Facebook script
        ''' </summary>
        ''' <remarks></remarks>
        Private _SDKFacebook As String

        ''' <summary>
        ''' Facebook subscription script
        ''' </summary>
        ''' <remarks></remarks>
        Private _SubscriptionScript As String

        ''' <summary>
        ''' Twitter script
        ''' </summary>
        ''' <remarks></remarks>
        Private _TweetScript As String

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEShareBar", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        #End Region 'Constructors

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N137"), _
        LocalizableDescAtt("_D137"), _
        Editor(GetType(UITypeShareBar), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Config() As FrmShareBar.ConfigShareBar
            Get
                If _config Is Nothing Then _config = New FrmShareBar.ConfigShareBar()
                Return _config
            End Get
            Set(ByVal value As FrmShareBar.ConfigShareBar)
                _config = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property FollowScript() As String
            Get
                If _FollowScript Is Nothing Then _TweetScript = New String("")
                Return _FollowScript
            End Get
            Set(ByVal value As String)
                _FollowScript = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property GPlusScript() As String
            Get
                If _GPlusScript Is Nothing Then _GPlusScript = New String("")
                Return _GPlusScript
            End Get
            Set(ByVal value As String)
                _GPlusScript = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property LikeScript() As String
            Get
                If _LikeScript Is Nothing Then _LikeScript = New String("")
                Return _LikeScript
            End Get
            Set(ByVal value As String)
                _LikeScript = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property SDKFacebook() As String
            Get
                If _SDKFacebook Is Nothing Then _SDKFacebook = New String("")
                Return _SDKFacebook
            End Get
            Set(ByVal value As String)
                _SDKFacebook = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property SubscriptionScript() As String
            Get
                If _SubscriptionScript Is Nothing Then _TweetScript = New String("")
                Return _SubscriptionScript
            End Get
            Set(ByVal value As String)
                _SubscriptionScript = value
            End Set
        End Property

        <Browsable(False)> _
        Public Property TweetScript() As String
            Get
                If _TweetScript Is Nothing Then _TweetScript = New String("")
                Return _TweetScript
            End Get
            Set(ByVal value As String)
                _TweetScript = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0240
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupCommunity"
            info.ToolBoxIco = My.Resources.WEGPlus
            info.ToolBoxDescription = ""
            info.AutoOpenProperty = "Config"
            info.SortPropertyList.Add(New SortProperty("Config", "Tools.png", LocalizableOpen._0206))
            Return info
        End Function

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEShareBar.js", "WEFiles/Client/WEShareBar.js")
            MyBase.OnInitExternalFiles()
        End Sub

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)

            configStylesZones.Add(New ConfigStylesZone("buttonTwitterTweet", LocalizableOpen._0266, LocalizableOpen._0266))
            configStylesZones.Add(New ConfigStylesZone("buttonTwitterFollow", LocalizableOpen._0267, LocalizableOpen._0267))
            configStylesZones.Add(New ConfigStylesZone("buttonGooglePlus", LocalizableOpen._0268, LocalizableOpen._0268))
            configStylesZones.Add(New ConfigStylesZone("buttonFacebookLike", LocalizableOpen._0264, LocalizableOpen._0264))
            configStylesZones.Add(New ConfigStylesZone("buttonFacebookSubscribe", LocalizableOpen._0265, LocalizableOpen._0265))

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                'display if no select file is in the editeur
                writer.WriteBeginTag("table")
                If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then
                    writer.WriteAttribute("style", "width:100%;height:70px;background-color:#999999;")
                Else
                    writer.WriteAttribute("style", "width:100%;height:24px;background-color:#999999;")
                End If

                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("img")

                If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then

                    writer.WriteAttribute("src", Path.CombinePath(Utils.EditorModCSSPath, "images/bigLogoShareBar.png"))
                Else
                    writer.WriteAttribute("src", Path.CombinePath(Utils.EditorModCSSPath, "images/smallLogoShareBar.png"))
                End If

                writer.Write(HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")
            Else

                If Config.ButtonsEnabled And FrmShareBar.ConfigShareBar.ENUbuttonsState.likeButton Or Config.ButtonsEnabled And FrmShareBar.ConfigShareBar.ENUbuttonsState.subscribe Then
                    writer.WriteLine()
                    writer.WriteBeginTag("div")
                    writer.WriteAttribute("id", "fb-root")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.WriteEndTag("div")

                    writer.WriteBeginTag("script")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    Dim uriCultureCode As String = String.Concat(Me.Page.CultureTrueCode.Split("-")(0).ToLower, "_", Me.Page.CultureTrueCode.Split("-")(0).ToUpper)
                    writer.Write("(function(d, s, id) {var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return;js = d.createElement(s); js.id = id;js.src = ""http://connect.facebook.net/" & uriCultureCode & "/all.js#xfbml=1"";fjs.parentNode.insertBefore(js, fjs);}(document, 'script', 'facebook-jssdk'));")
                    writer.WriteEndTag("script")
                    writer.WriteLine()
                End If

                'Button display according to the user configuration

                'Twitter
                If Config.ButtonsEnabled And FrmShareBar.ConfigShareBar.ENUbuttonsState.tweet Then Render_TwitterScript(writer) : writer.WriteLine()
                'following Tweet
                If Config.ButtonsEnabled And FrmShareBar.ConfigShareBar.ENUbuttonsState.follow Then Render_FollowScript(writer) : writer.WriteLine()
                'Google+
                If Config.ButtonsEnabled And FrmShareBar.ConfigShareBar.ENUbuttonsState.plus Then Render_GooglePlusScript(writer) : writer.WriteLine()
                'Facebook like
                If Config.ButtonsEnabled And FrmShareBar.ConfigShareBar.ENUbuttonsState.likeButton Then Render_LikeScript(writer) : writer.WriteLine()
                'Facebook subscription
                If Config.ButtonsEnabled And FrmShareBar.ConfigShareBar.ENUbuttonsState.subscribe Then Render_SubscriptionScript(writer) : writer.WriteLine()

                If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then
                    Dim styleZone As StylesZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonGooglePlus")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto") : styleZone.BaseStyles.Margin.Top.SetCss("2px")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonFacebookLike")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonTwitterTweet")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonFacebookSubscribe")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto")

                Else
                    Dim styleZone As StylesZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonGooglePlus")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("70px")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonFacebookLike")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonTwitterTweet")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("100px")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonFacebookSubscribe")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("130px")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonTwitterFollow")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("210px")
                End If

            End If

            MyBase.RenderEndTag(writer)
        End Sub

        ''' <summary>
        ''' follow twitter script render
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_FollowScript(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonTwitterFollow")
            writer.Write(HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", String.Concat("https://twitter.com/", Config.TwitterAccount))
            writer.WriteAttribute("class", "twitter-follow-button")
            If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then
                writer.WriteAttribute("data-show-count", "false")
            Else
                writer.WriteAttribute("data-show-count", "true")
            End If

            writer.WriteAttribute("data-lang", Me.Page.CultureTrueCode)
            If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then writer.WriteAttribute("data-align", "vertical")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Write(String.Concat(LocalizableFormAndConverter._0202, " @", Config.TwitterAccount))
            writer.WriteEndTag("a")
            writer.WriteBeginTag("script")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Write("!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=""http://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");")
            writer.WriteEndTag("script")
            writer.WriteEndTag("div")
        End Sub

        ''' <summary>
        ''' google+'s script render
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_GooglePlusScript(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonGooglePlus")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteBeginTag("g:plusone")
            If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then
                writer.WriteAttribute("size", "tall")
            Else
                writer.WriteAttribute("size", "medium")
            End If

            If Not String.IsNullOrEmpty(Config.Url) Then writer.WriteAttribute("href", Config.Url)
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("g:plusone")
            writer.WriteEndTag("div")
        End Sub

        ''' <summary>
        ''' like script render (facebook)
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_LikeScript(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonFacebookLike")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "fb-like")
            If Not String.IsNullOrEmpty(Config.Url) Then writer.WriteAttribute("data-href", Config.Url)
            If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then
                writer.WriteAttribute("data-layout", "box_count")
            Else
                writer.WriteAttribute("data-layout", "button_count")
            End If
            writer.WriteAttribute("data-send", "false")
            writer.WriteAttribute("data-show-faces", "false")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteEndTag("div")
        End Sub

        ''' <summary>
        ''' facebook's subscription script render
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_SubscriptionScript(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonFacebookSubscribe")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "fb-subscribe")
            writer.WriteAttribute("data-href", Config.FacebookPage)
            writer.WriteAttribute("data-show-faces", "false")
            If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then
                writer.WriteAttribute("data-layout", "box_count")
            Else
                writer.WriteAttribute("data-layout", "button_count")
            End If
            writer.WriteAttribute("data-width", "150")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteEndTag("div")
        End Sub

        ''' <summary>
        ''' tweet's script render
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_TwitterScript(ByVal writer As HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonTwitterTweet")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", "https://twitter.com/share")
            writer.WriteAttribute("class", "twitter-share-button")
            If Not String.IsNullOrEmpty(Config.Url) Then writer.WriteAttribute("data-url", Config.Url)
            writer.WriteAttribute("data-lang", Me.Page.CultureTrueCode)
            If Config.ButtonsSize = FrmShareBar.ConfigShareBar.ENUmode.big Then writer.WriteAttribute("data-count", "vertical")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Write("Tweeter")
            writer.WriteEndTag("a")
            writer.WriteBeginTag("script")
            writer.Write(HtmlTextWriter.TagRightChar)
            writer.Write("!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=""http://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");")
            writer.WriteEndTag("script")
            writer.WriteEndTag("div")
        End Sub

        #End Region 'Methods

    End Class

End Namespace

