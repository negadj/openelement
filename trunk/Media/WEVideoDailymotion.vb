Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.DataType


Namespace Elements.Media

    <Serializable()> _
    Public Class WEVideoDailymotion
        Inherits ElementBase

#Region "Propriété"

        Private _DailymotionURL As LocalizableString

        '<Category("Edition"), _
        'DisplayName("URL"), _
        'Description("URL de la vidéo Dailymotion" & vbCrLf & ""), _
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N019"), _
        Ressource.localizable.LocalizableDescAtt("_D032"), _
        Editor(GetType(Editors.UITypeDailymotion), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property DailymotionURL() As LocalizableString
            Get
                If _DailymotionURL Is Nothing Then _DailymotionURL = New LocalizableString
                Return _DailymotionURL
            End Get
            Set(ByVal value As LocalizableString)
                _DailymotionURL = value
            End Set
        End Property

#End Region

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEVideoDailymotion", page, parentID, templateName)
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0066 ' "Vidéo Dailymotion"
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupMedia"
            info.ToolBoxIco = My.Resources.WEVideo
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0067 '"Ajouter une vidéo Dailymotion"
            info.AutoOpenProperty = "DailymotionURL"
            info.SortPropertyList.Add(New SortProperty("DailymotionURL", "movie.png", My.Resources.text.LocalizableOpen._0058)) '"Sélection de l'URL."
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            MyBase.OnOpen()
        End Sub



#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)

            Dim url As String
            If String.Compare(Me.Page.Culture, "DEFAULT") Then
                url = DailymotionURL.GetValue()
            Else
                url = DailymotionURL.GetValue(Me.Page.Culture)
            End If

            If Not (String.IsNullOrEmpty(url) Or MyBase.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Editor) Then
                Dim Script As String = DailymotionURL.GetValue(Me.Page.Culture)

                If Script.StartsWith("http://") Then
                    'ancienne methode dailymotion (permalink)

                    writer.WriteBeginTag("object")
                    writer.WriteAttribute("width", "100%")
                    writer.WriteAttribute("height", "100%")
                    writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
                    writer.WriteLine()

                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "movie")
                    writer.WriteAttribute("value", url)
                    writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
                    writer.WriteLine()

                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "allowFullScreen")
                    writer.WriteAttribute("value", "true")
                    writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
                    writer.WriteLine()

                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "allowscriptaccess")
                    writer.WriteAttribute("value", "always")
                    writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
                    writer.WriteLine()

                    writer.WriteBeginTag("param")
                    writer.WriteAttribute("name", "wmode")
                    writer.WriteAttribute("value", "transparent")
                    writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

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
                    writer.Write(Script)
                End If



            Else

                'Affichage Si aucun fichier selectionné et dans l'editeur
                writer.WriteBeginTag("table")
                writer.WriteAttribute("style", "width:100%;height:100%;background-color:#999999;")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteFullBeginTag("tr")
                writer.WriteBeginTag("td")
                writer.WriteAttribute("style", "text-align:center;vertical-align:middle")
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

                writer.WriteBeginTag("img")
                writer.WriteAttribute("src", IO.Path.Combine(Utils.EditorModCSSPath, "images/movieDailymotion.png"))
                writer.WriteAttribute("alt", "")
                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)

                writer.WriteEndTag("td")
                writer.WriteEndTag("tr")
                writer.WriteEndTag("table")

            End If



            MyBase.RenderEndTag(writer)

        End Sub

#End Region

    End Class

End Namespace