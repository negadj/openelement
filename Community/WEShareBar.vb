Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.ElementWECommon.Community.Forms.FrmShareBar.ConfigShareBar


Namespace Elements.Community
    <Serializable()> _
    Public Class WEShareBar
        Inherits ElementBase

#Region "Private variable"

        ''' <summary>
        ''' behavior Share bar config  
        ''' </summary>
        ''' <remarks></remarks>
        Private _config As ElementWECommon.Community.Forms.FrmShareBar.ConfigShareBar

        ''' <summary>
        ''' Facebook script
        ''' </summary>
        ''' <remarks></remarks>
        Private _SDKFacebook As String
        ''' <summary>
        ''' Facebook like script
        ''' </summary>
        ''' <remarks></remarks>
        Private _LikeScript As String
        ''' <summary>
        ''' Facebook subscription script
        ''' </summary>
        ''' <remarks></remarks>
        Private _SubscriptionScript As String
        ''' <summary>
        ''' Google plus script
        ''' </summary>
        ''' <remarks></remarks>
        Private _GPlusScript As String
        ''' <summary>
        ''' twitter follow script
        ''' </summary>
        ''' <remarks></remarks>
        Private _FollowScript As String
        ''' <summary>
        ''' Twitter script
        ''' </summary>
        ''' <remarks></remarks>
        Private _TweetScript As String
#End Region

#Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N137"), _
        Ressource.localizable.LocalizableDescAtt("_D137"), _
       Editor(GetType(Community.Editors.UITypeShareBar), GetType(Drawing.Design.UITypeEditor)), _
       Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property Config() As ElementWECommon.Community.Forms.FrmShareBar.ConfigShareBar
            Get
                If _config Is Nothing Then _config = New ElementWECommon.Community.Forms.FrmShareBar.ConfigShareBar()
                Return _config
            End Get
            Set(ByVal value As ElementWECommon.Community.Forms.FrmShareBar.ConfigShareBar)
                _config = value
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

#End Region

#Region "Builder required function"


        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEShareBar", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0240
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupCommunity"
            info.ToolBoxIco = My.Resources.WEGPlus
            info.ToolBoxDescription = ""
            info.AutoOpenProperty = "Config"
            info.SortPropertyList.Add(New SortProperty("Config", "Tools.png", My.Resources.text.LocalizableOpen._0206))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)

            configStylesZones.Add(New StylesManager.ConfigStylesZone("buttonTwitterTweet", My.Resources.text.LocalizableOpen._0266, My.Resources.text.LocalizableOpen._0266))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("buttonTwitterFollow", My.Resources.text.LocalizableOpen._0267, My.Resources.text.LocalizableOpen._0267))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("buttonGooglePlus", My.Resources.text.LocalizableOpen._0268, My.Resources.text.LocalizableOpen._0268))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("buttonFacebookLike", My.Resources.text.LocalizableOpen._0264, My.Resources.text.LocalizableOpen._0264))
            configStylesZones.Add(New StylesManager.ConfigStylesZone("buttonFacebookSubscribe", My.Resources.text.LocalizableOpen._0265, My.Resources.text.LocalizableOpen._0265))

            MyBase.OnOpen(configStylesZones)

        End Sub

        Protected Overrides Sub OnInitExternalFiles()
            MyBase.AddExternalScripts(Common.EnuScriptType.Javascript, "ElementsLibrary\Common\Client\WEShareBar.js", "WEFiles/Client/WEShareBar.js")
            MyBase.OnInitExternalFiles()
        End Sub

#End Region

#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            If MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor Then
                'display if no select file is in the editeur
                writer.WriteBeginTag("table")
                If Config.ButtonsSize = ENUmode.big Then
                    writer.WriteAttribute("style", "width:100%;height:70px;background-color:#999999;")
                Else
                    writer.WriteAttribute("style", "width:100%;height:24px;background-color:#999999;")
                End If

                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("img")


                If Config.ButtonsSize = ENUmode.big Then

                    writer.WriteAttribute("src", openElement.Tools.Path.CombinePath(Utils.EditorModCSSPath, "images/bigLogoShareBar.png"))
                Else
                    writer.WriteAttribute("src", openElement.Tools.Path.CombinePath(Utils.EditorModCSSPath, "images/smallLogoShareBar.png"))
                End If

                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")
            Else

                If Config.ButtonsEnabled And ENUbuttonsState.likeButton Or Config.ButtonsEnabled And ENUbuttonsState.subscribe Then
                    writer.WriteLine()
                    writer.WriteBeginTag("div")
                    writer.WriteAttribute("id", "fb-root")
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteEndTag("div")

                    writer.WriteBeginTag("script")
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    Dim uriCultureCode As String = String.Concat(Me.Page.CultureTrueCode.Split("-")(0).ToLower, "_", Me.Page.CultureTrueCode.Split("-")(0).ToUpper)
                    writer.Write("(function(d, s, id) {var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return;js = d.createElement(s); js.id = id;js.src = ""http://connect.facebook.net/" & uriCultureCode & "/all.js#xfbml=1"";fjs.parentNode.insertBefore(js, fjs);}(document, 'script', 'facebook-jssdk'));")
                    writer.WriteEndTag("script")
                    writer.WriteLine()
                End If


                'Button display according to the user configuration

                'Twitter
                If Config.ButtonsEnabled And ENUbuttonsState.tweet Then Render_TwitterScript(writer) : writer.WriteLine()
                'following Tweet
                If Config.ButtonsEnabled And ENUbuttonsState.follow Then Render_FollowScript(writer) : writer.WriteLine()
                'Google+
                If Config.ButtonsEnabled And ENUbuttonsState.plus Then Render_GooglePlusScript(writer) : writer.WriteLine()
                'Facebook like
                If Config.ButtonsEnabled And ENUbuttonsState.likeButton Then Render_LikeScript(writer) : writer.WriteLine()
                'Facebook subscription
                If Config.ButtonsEnabled And ENUbuttonsState.subscribe Then Render_SubscriptionScript(writer) : writer.WriteLine()

                If Config.ButtonsSize = ENUmode.big Then
                    Dim styleZone As StylesManager.StylesZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonGooglePlus")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto") : styleZone.BaseStyles.Margin.Top.SetCss("2px")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonFacebookLike")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonTwitterTweet")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto")

                    styleZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonFacebookSubscribe")
                    If styleZone IsNot Nothing Then styleZone.BaseStyles.Width.SetCss("auto")

                Else
                    Dim styleZone As StylesManager.StylesZone = MyBase.StylesSkin.StylesSkinModel.FindStylesZone("buttonGooglePlus")
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
        ''' like script render (facebook)
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_LikeScript(ByVal writer As Common.HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonFacebookLike")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "fb-like")
            If Not String.IsNullOrEmpty(Config.Url) Then writer.WriteAttribute("data-href", Config.Url)
            If Config.ButtonsSize = ENUmode.big Then
                writer.WriteAttribute("data-layout", "box_count")
            Else
                writer.WriteAttribute("data-layout", "button_count")
            End If
            writer.WriteAttribute("data-send", "false")
            writer.WriteAttribute("data-show-faces", "false")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteEndTag("div")
        End Sub

        ''' <summary>
        ''' facebook's subscription script render
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_SubscriptionScript(ByVal writer As Common.HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonFacebookSubscribe")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "fb-subscribe")
            writer.WriteAttribute("data-href", Config.FacebookPage)
            writer.WriteAttribute("data-show-faces", "false")
            If Config.ButtonsSize = ENUmode.big Then
                writer.WriteAttribute("data-layout", "box_count")
            Else
                writer.WriteAttribute("data-layout", "button_count")
            End If
            writer.WriteAttribute("data-width", "150")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteEndTag("div")
        End Sub

        ''' <summary>
        ''' google+'s script render
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_GooglePlusScript(ByVal writer As Common.HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonGooglePlus")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteBeginTag("g:plusone")
            If Config.ButtonsSize = ENUmode.big Then
                writer.WriteAttribute("size", "tall")
            Else
                writer.WriteAttribute("size", "medium")
            End If

            If Not String.IsNullOrEmpty(Config.Url) Then writer.WriteAttribute("href", Config.Url)
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("g:plusone")
            writer.WriteEndTag("div")
        End Sub

        ''' <summary>
        ''' tweet's script render
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_TwitterScript(ByVal writer As Common.HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonTwitterTweet")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", "https://twitter.com/share")
            writer.WriteAttribute("class", "twitter-share-button")
            If Not String.IsNullOrEmpty(Config.Url) Then writer.WriteAttribute("data-url", Config.Url)
            writer.WriteAttribute("data-lang", Me.Page.CultureTrueCode)
            If Config.ButtonsSize = ENUmode.big Then writer.WriteAttribute("data-count", "vertical")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write("Tweeter")
            writer.WriteEndTag("a")
            writer.WriteBeginTag("script")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write("!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=""http://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");")
            writer.WriteEndTag("script")
            writer.WriteEndTag("div")
        End Sub

        ''' <summary>
        ''' follow twitter script render
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Render_FollowScript(ByVal writer As Common.HtmlWriter)
            writer.WriteBeginTag("div")
            writer.WriteAttribute("class", "OESZ_buttonTwitterFollow")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("a")
            writer.WriteAttribute("href", String.Concat("https://twitter.com/", Config.TwitterAccount))
            writer.WriteAttribute("class", "twitter-follow-button")
            If Config.ButtonsSize = ENUmode.big Then
                writer.WriteAttribute("data-show-count", "false")
            Else
                writer.WriteAttribute("data-show-count", "true")
            End If

            writer.WriteAttribute("data-lang", Me.Page.CultureTrueCode)
            If Config.ButtonsSize = ENUmode.big Then writer.WriteAttribute("data-align", "vertical")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write(String.Concat(My.Resources.text.LocalizableFormAndConverter._0202, " @", Config.TwitterAccount))
            writer.WriteEndTag("a")
            writer.WriteBeginTag("script")
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.Write("!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=""http://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");")
            writer.WriteEndTag("script")
            writer.WriteEndTag("div")
        End Sub
#End Region

    End Class

  
End Namespace
