Imports System.ComponentModel
Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports openElement
Imports openElement.WebElement.Editors.Control.CtlEditListOf
Imports openElement.WebElement.ElementWECommon.Interactivity.Forms
Imports openElement.WebElement.LinksManager
Imports System.Xml
Imports System.Collections.Generic


Namespace Elements.Interactivity

    'our Rss elt
    <Serializable()> _
    Public Class WERssWriter
        Inherits ElementBase

#Region "Properties"

        Private _RssUrl As LinksManager.Link 'XML URL
        Private _RssListArticles As openElement.WebElement.DataType.WERss.RssListArticle 'List of article
        Private _RssMeta As FrmRss.MetaRSS 'contains metadata rss ( we can edit this separately of the article list)
        Private _ListUrlFluxRssExistant As List(Of LinksManager.Link)
        Private _IsRanged As Boolean

        ''' <summary>
        ''' list of exist articles of Xml feeds 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False), Common.Attributes.EditListOf.ContainsListOfObject()> _
       Public Property ListUrlFluxRssExistant() As List(Of LinksManager.Link)
            Get

                If Me._ListUrlFluxRssExistant Is Nothing Then Me._ListUrlFluxRssExistant = New List(Of LinksManager.Link)
                Return Me._ListUrlFluxRssExistant

            End Get
            Set(ByVal value As List(Of LinksManager.Link))
                Me._ListUrlFluxRssExistant = value
            End Set
        End Property

        ''' <summary>
        ''' list of personal articles of rss feeds
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N217"), _
        Ressource.localizable.LocalizableDescAtt("_D217"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeEditListOf), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
       Public Property RssListArticles() As openElement.WebElement.DataType.WERss.RssListArticle
            Get
                If _RssListArticles Is Nothing Then _RssListArticles = New openElement.WebElement.DataType.WERss.RssListArticle()
                Return _RssListArticles
            End Get
            Set(ByVal value As openElement.WebElement.DataType.WERss.RssListArticle)
                _RssListArticles = value
                Call CreateRssLink()
            End Set
        End Property

        ''' <summary>
        ''' name of xml file
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public ReadOnly Property FileName() As String
            Get
                Return String.Concat(Me.ID, ".xml")
            End Get
        End Property

        ''' <summary>
        ''' path of rss feed
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property RssUrl() As Link
            Get
                If _RssUrl Is Nothing Then _RssUrl = New Link
                Return _RssUrl
            End Get
            Set(ByVal value As Link)
                _RssUrl = value
            End Set
        End Property

        ''' <summary>
        ''' Config infos of rss feed (metadata)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N216"), _
        Ressource.localizable.LocalizableDescAtt("_D216"), _
        Editor(GetType(Editors.UITypeRss), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.None)> _
        Public Property RssMeta() As FrmRss.MetaRSS
            Get
                If _RssMeta Is Nothing Then _RssMeta = New FrmRss.MetaRSS
                Return _RssMeta
            End Get
            Set(ByVal value As FrmRss.MetaRSS)
                _RssMeta = value
            End Set
        End Property


#End Region


#Region "Builder required function"

        Public Sub New(ByVal Page As Page, ByVal ParentID As String, ByVal TemplateName As String)
            MyBase.New(EnuElementType.PageEdit, "WERssWriter", Page, ParentID, TemplateName)
            MyBase.TypeResize = EnuTypeResize.None
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0362
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupInteractivity"
            info.ToolBoxIco = My.Resources.WERssWriter
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0362
            info.AutoOpenProperty = "RssMeta"
            info.SortPropertyList.Add(New SortProperty("RssMeta", "tools.png", My.Resources.text.LocalizableOpen._0335))
            info.SortPropertyList.Add(New SortProperty("RssListArticles", "edit_list.png", My.Resources.text.LocalizableOpen._0361))
            Return info

        End Function

        Protected Overrides Sub OnOpen()
            Dim ConfigStylesZones As New List(Of StylesManager.ConfigStylesZone)
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("Icon", My.Resources.text.LocalizableOpen._0363, My.Resources.text.LocalizableOpen._0363))
            MyBase.OnOpen(ConfigStylesZones)
        End Sub

#End Region


#Region "Render"

        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)


            MyBase.RenderBeginTag(writer)
            writer.WriteBeginTag("a")
            writer.WriteHrefAttribute(Me, Me.RssUrl, False) 'Ecrit l'attribut Href avec les targets

            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)

            writer.WriteBeginTag("div") 'La div qui contient l'ariere plans de l'élément
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Icon")) 'Appelle la zone de style configurable
            writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            writer.WriteEndTag("div")
            writer.WriteEndTag("a")
            MyBase.RenderEndTag(writer)

        End Sub

#End Region


#Region "ListOfObject Event"
       
        Protected Overrides Function OnFrmEditListOfGetFormConfig() As openElement.WebElement.Editors.Control.CtlEditListOf.EditConfig
            Dim AddButtonList As New List(Of AddButton)
            AddButtonList.Add(New AddButton("AddArticle", My.Resources.text.LocalizableFormAndConverter._0185, Nothing))
            AddButtonList.Add(New AddButton("AddExistArticle", My.Resources.text.LocalizableFormAndConverter._0186, Nothing))
            Dim EditConfig As New EditConfig(My.Resources.text.LocalizableFormAndConverter._0183, My.Resources.text.LocalizableFormAndConverter._0184, AddButtonList)
            Return EditConfig
        End Function

        Protected Overrides Function OnFrmEditListOfAddNewItem(ByVal AddButton As AddButton, ByVal SelectedNodeTag As NodeTag) As List(Of Object) 'Methode appelé à l'ajout d'un élément dans une liste
            Dim NewObs As New List(Of Object)

            If AddButton.Name = "AddArticle" Then
                Dim newRssArticle As New openElement.WebElement.DataType.WERss.RSSArticle
                newRssArticle.Pubdate = Now
                newRssArticle.IsExist = False
                NewObs.Add(newRssArticle)
            End If

            If AddButton.Name = "AddExistArticle" Then

                Dim FrmExistRss As New FrmExistRss(Me, Me.ListUrlFluxRssExistant, Me.RssListArticles)

                If Me._IsRanged = False Then
                    Me.ListUrlFluxRssExistant.Add(New openElement.WebElement.LinksManager.Link())
                    Me.ListUrlFluxRssExistant.Add(New openElement.WebElement.LinksManager.Link())
                    Me.ListUrlFluxRssExistant.Item(0).UpdateLink(Link.EnuLinkType.FreeUrl, "http://rss.cnn.com/rss/edition_world.rss", MyBase.Page.Culture)
                    Me.ListUrlFluxRssExistant.Item(1).UpdateLink(Link.EnuLinkType.FreeUrl, "http://rss.cnn.com/rss/edition_business.rss", MyBase.Page.Culture)
                    Me._IsRanged = True
                End If

                If FrmExistRss.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'browse the list of selected articles of form  
                    For Each item As openElement.WebElement.DataType.WERss.RSSArticle In FrmExistRss.ListArticle.List
                        NewObs.Add(item)
                    Next

                End If

            End If
            Return NewObs
        End Function

#End Region


#Region "Ecriture du fichier"
        Private Sub CreateRssLink()

            Dim tempPath As String = Tools.Path.GetStructurePath(Tools.Enu.StructureType.Temp, , Me.FileName)
            Dim sitePath As String = String.Concat("WEFiles/Xml/", Me.FileName)

            Validate(Me.RssListArticles(), Me.RssMeta(), tempPath)
 

            RssUrl = MyBase.AddExternalScripts(Common.EnuScriptType.OtherScript, tempPath, sitePath, False)
           
        End Sub


#Region "Obsolte validate"
        'Dim document As XmlDocument = New XmlDocument() 'Instantiation d'un élément logiciel XmlDocument qui stock le document Xml
        ''document.LoadXml("<?xml version='1.0' encoding='UTF-8'?><rss version=""2.0"" xmlns:content=""http://purl.org/rss/1.0/modules/content/""></rss>") 'Chargement du Xml et création de la racine du document
        ''document.LoadXml("<?xml version='1.0' encoding='UTF-8'?><?xml-stylesheet type='text/xsl' href='http://rss.lemonde.fr/xsl/fr/rss.xsl'?><rss xmlns:itunes='http://www.itunes.com/dtds/podcast-1.0.dtd' xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:taxo='http://purl.org/rss/1.0/modules/taxonomy/' xmlns:rdf='http://www.w3.org/1999/02/22-rdf-syntax-ns#' version='2.0'></rss>")
        'document.LoadXml("<?xml version='1.0' encoding='UTF-8'?><rss version='2.0' xmlns:content='http://purl.org/rss/1.0/modules/content/' xmlns:wfw='http://wellformedweb.org/CommentAPI/' xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:atom='http://www.w3.org/2005/Atom' xmlns:sy='http://purl.org/rss/1.0/modules/syndication/' xmlns:slash='http://purl.org/rss/1.0/modules/slash/'></rss>")
        'Dim title As XmlElement 'Création d'un élément Xml
        'title = document.CreateElement("title") 'Insertion de l'élément dans le document Xml
        'title.InnerText = MetasRss.Title.GetValue.ToString 'Insertion de données dans la balise 'title'

        'Dim desc As XmlElement
        'desc = document.CreateElement("description")
        'desc.InnerText = MetasRss.Description.GetValue.ToString

        'Dim link As XmlElement
        'link = document.CreateElement("link")
        'link.InnerText = MyBase.GetLink(MetasRss.Link)

        'Dim pubdate As XmlElement
        'pubdate = document.CreateElement("pubDate")
        'pubdate.InnerText = MetasRss.Pubdate.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'", New System.Globalization.CultureInfo("en-US"))

        'Dim lastBuildDate As XmlElement
        'lastBuildDate = document.CreateElement("lastBuildDate")
        'lastBuildDate.InnerText = MetasRss.Pubdate.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'", New System.Globalization.CultureInfo("en-US"))

        'Dim channel As XmlElement
        'channel = document.CreateElement("channel")
        'document.DocumentElement.AppendChild(channel) 'Ajout d'un enfant qui est la balise channel dans la racine
        'channel.AppendChild(title) ' Ajout de l'enfant title dans le parent channel
        'channel.AppendChild(desc) ' Ajout de l'enfant description dans le parent channel
        'channel.AppendChild(link) ' Ajout de l'enfant link dans le parent channel
        'channel.AppendChild(pubdate) ' Ajout de l'enfant pubdate dans le parent channel
        'channel.AppendChild(lastBuildDate) ' Ajout de l'enfant lastBuildDate dans le parent channel


        'For Each contentArticle In lisArticle.List 'Pour cahque article de la liste une boucle est effectué

        '    Dim content As String 'On reprent toute les valeur pour chaque ellement de la liste et on le stock dans content
        '    Dim pubdateString As String = String.Concat("<pubDate>", contentArticle.Pubdate.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'", New System.Globalization.CultureInfo("en-US")), "</pubDate>", vbCrLf)

        '    Dim titleString As String = String.Concat("<title>", contentArticle.Title.GetValue.ToString, "</title>", vbCrLf)
        '    Dim linkString As String = String.Concat("<link>", contentArticle.Link.ToString, "</link>", vbCrLf)
        '    content = String.Concat(titleString, linkString)


        '    Dim descriptionString As String = String.Concat("<description>", System.Web.HttpUtility.HtmlEncode(contentArticle.Description.GetValue.ToString), "</description>", vbCrLf)
        '    content = String.Concat(content, descriptionString)

        '    content = String.Concat(content, pubdateString)
        '    'Dans la norme W3C il faut spécifier si le guid est une URI ou pas
        '    If contentArticle.IsExist = False And Not contentArticle.Guid.ToString.StartsWith("http://") Then
        '        Dim guiString As String = String.Concat("<guid isPermaLink=""false"">", contentArticle.Guid.ToString, "</guid>", vbCrLf)
        '        content = String.Concat(content, guiString)
        '    Else : Dim guiString As String = String.Concat("<guid isPermaLink=""true"">", contentArticle.Guid.ToString, "</guid>", vbCrLf)
        '        content = String.Concat(content, guiString)
        '    End If

        '    If contentArticle.Media.Url.ToString <> "" Then
        '        Dim enclosureString As String = String.Concat("<enclosure url='", contentArticle.Media.Url.ToString, "' length='", contentArticle.Media.Lenght.ToString, "' type='", contentArticle.Media.Type, "'/>", vbCrLf)
        '        content = String.Concat(content, enclosureString)
        '    End If


        '    Dim item As XmlElement 'Création d'un item
        '    Try
        '        item = document.CreateElement("item")
        '        'Remplissages de item par le contenu de content
        '        item.InnerXml = content
        '    Catch ex As Exception
        '        ErrorMsg = String.Concat(ErrorMsg, vbCrLf, "- ", contentArticle.Title.GetValue.ToString)
        '        Continue For
        '    End Try

        '    channel.AppendChild(item) ' Ajout de l'iteme dans le channel

        'Next

        'If Not String.IsNullOrEmpty(ErrorMsg) Then
        '    OEMsgBox(String.Format(My.Resources.text.LocalizableOpen._0367, ErrorMsg), MsgBoxType.Err)
        'End If

        'Try
        '    document.Save(sourcePath) 'Sauvegarde durésultat du document Xml dans le stream
        'Catch ex As Exception

        '    OEBug.Capture(ex, True, True)
        'End Try
#End Region

        ''' <summary>
        ''' render of xml file of this rss feed
        ''' </summary>
        ''' <param name="lisArticle"></param>
        ''' <param name="metasRss"></param>
        ''' <param name="tempPath"></param>
        ''' <remarks></remarks>
        Public Sub Validate(ByVal lisArticle As openElement.WebElement.DataType.WERss.RssListArticle, ByVal metasRss As FrmRss.MetaRSS, ByVal tempPath As String)

            Dim domaine As String = MyBase.GetLink(metasRss.Link)
            If Not domaine.EndsWith("/") Then
                domaine = String.Concat(domaine, "/")
            End If

            Using streamWriter As New IO.StreamWriter(tempPath)
                streamWriter.WriteLine("<?xml version='1.0' encoding='UTF-8'?>")
                streamWriter.WriteLine("<rss version='2.0' ")
                streamWriter.WriteLine("xmlns:content='http://purl.org/rss/1.0/modules/content/' ")
                streamWriter.WriteLine("xmlns:wfw='http://wellformedweb.org/CommentAPI/' ")
                streamWriter.WriteLine("xmlns:dc='http://purl.org/dc/elements/1.1/' ")
                streamWriter.WriteLine("xmlns:atom='http://www.w3.org/2005/Atom' ")
                streamWriter.WriteLine("xmlns:sy='http://purl.org/rss/1.0/modules/syndication/' ")
                streamWriter.WriteLine("xmlns:slash='http://purl.org/rss/1.0/modules/slash/'>")
                streamWriter.WriteLine("<channel>")
                streamWriter.WriteLine(String.Concat("<title>", metasRss.Title.GetValue.ToString(), "</title>"))
                streamWriter.WriteLine(String.Concat("<description>", metasRss.Description.GetValue.ToString(), "</description>"))
                streamWriter.WriteLine(String.Concat("<atom:link href='", domaine, "' rel='self' type='application/rss+xml' />"))

                streamWriter.WriteLine("<link rel=""shortcut icon"" href=""favicon.oe.ico"" />")

                streamWriter.WriteLine(String.Concat("<link>", domaine, "</link>"))
                metasRss.Link.GetLinkType()
                streamWriter.WriteLine(String.Concat("<lastBuildDate>", metasRss.Pubdate.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'"), "</lastBuildDate>"))
                streamWriter.WriteLine(String.Concat("<pubDate>", metasRss.Pubdate.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'"), "</pubDate>"))
                streamWriter.WriteLine(String.Concat("<language>", Me.Page.CultureTrueCode, "</language>"))
                streamWriter.WriteLine("<generator>openElement.com</generator>")


                For Each contentArticle In lisArticle.List

                    'we take all values for every element of the list, and we store it in 'content'
                    Dim content As String
                    Dim pubdateString As String = String.Concat("<pubDate>", contentArticle.Pubdate.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'", New System.Globalization.CultureInfo("en-US")), "</pubDate>", vbCrLf)

                    Dim titleString As String = String.Concat("<title>", contentArticle.Title.GetValue.ToString, "</title>", vbCrLf)

                    Dim contentArticleLink As String = MyBase.GetAbsoluteLink(contentArticle.Link)

                    If contentArticle.Link.GetLinkType = Link.EnuLinkType.AutoPage Or contentArticle.Link.GetLinkType = Link.EnuLinkType.CustomPage Then
                        contentArticleLink = String.Concat(domaine, contentArticleLink)
                    End If

                    Dim linkString As String = String.Concat("<link>", contentArticleLink, "</link>", vbCrLf)
                    content = String.Concat(titleString, linkString)
                     
                    Dim descriptionString As String = String.Concat("<description>", contentArticle.Description.GetValue(Me.Page.Culture), "</description>", vbCrLf)
                    content = String.Concat(content, descriptionString)

                    content = String.Concat(content, pubdateString)
                    'in W3C norme, we must  specified if the guid code is an URI or not 
                    If contentArticle.IsExist = False And Not contentArticle.Guid.ToString.StartsWith("http://") Then
                        Dim guiString As String = String.Concat("<guid isPermaLink=""false"">", contentArticle.Guid.ToString, "</guid>", vbCrLf)
                        content = String.Concat(content, guiString)
                    Else : Dim guiString As String = String.Concat("<guid isPermaLink=""true"">", contentArticle.Guid.ToString, "</guid>", vbCrLf)
                        content = String.Concat(content, guiString)
                    End If

                    If contentArticle.Media.Url.ToString <> "" Then
                        Dim enclosureString As String = String.Concat("<enclosure url='", contentArticle.Media.Url.ToString, "' length='", contentArticle.Media.Lenght.ToString, "' type='", contentArticle.Media.Type, "'/>", vbCrLf)
                        content = String.Concat(content, enclosureString)
                    End If
                    streamWriter.WriteLine(String.Concat("<item>", content, "</item>"))


                Next


                streamWriter.WriteLine("</channel>")
                streamWriter.WriteLine("</rss>")
                streamWriter.Flush()
                streamWriter.Close()

            End Using

        End Sub

#End Region

    End Class

End Namespace