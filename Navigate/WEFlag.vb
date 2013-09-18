Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Text
Imports System.Web.UI

Imports openElement.Tools
Imports openElement.WebElement.Common
Imports openElement.WebElement.Common.Attributes
Imports openElement.WebElement.Elements
Imports openElement.WebElement.LinksManager
Imports openElement.WebElement.StylesManager
Imports openElement.WebSite.Config

Imports WebElement.Elements.Navigate.Editors
Imports WebElement.My.Resources.text
Imports WebElement.Ressource.localizable

Namespace Elements.Navigate

    <Serializable> _
    Public Class WEFlag
        Inherits ElementBase

        #Region "Fields"

        <ContainsLinks> _
        Private _ListConfigLanguage As List(Of WEConfigLanguage)
        Private _ViewType As EnuViewType

        #End Region 'Fields

        #Region "Constructors"

        Public Sub New(ByVal page As openElement.WebElement.Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEFlag", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            UpdateLinkFlag()
        End Sub

        #End Region 'Constructors

        #Region "Enumerations"

        Public Enum EnuViewType As Short
            OnlyFlag = 0
            OnlyText = 1
            FlagAndText = 2
        End Enum

        #End Region 'Enumerations

        #Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N237"), _
        LocalizableDescAtt("_D237"), _
        Editor(GetType(UITypeListConfigLanguage), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ListConfigLanguage() As List(Of WEConfigLanguage)
            Get
                If _ListConfigLanguage Is Nothing Then
                    _ListConfigLanguage = New List(Of WEConfigLanguage)
                End If

                Return _ListConfigLanguage
            End Get
            Set(ByVal value As List(Of WEConfigLanguage))
                _ListConfigLanguage = value
            End Set
        End Property

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N237"), _
        LocalizableDescAtt("_D237"), _
        Editor(GetType(UITypeFlagView), GetType(UITypeEditor)), _
        PageUpdateMode(PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ViewType() As EnuViewType
            Get
                Return _ViewType
            End Get
            Set(ByVal value As EnuViewType)
                _ViewType = value
            End Set
        End Property

        #End Region 'Properties

        #Region "Methods"

        Protected Overrides Function OnGetInfo() As ElementInfo
            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = LocalizableOpen._0109
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEFlag
            info.ToolBoxDescription = LocalizableOpen._0110
            info.SortPropertyList.Add(New SortProperty("ListConfigLanguage", "tools.png", LocalizableOpen._0030))
            Return info
        End Function

        Protected Overrides Sub OnOpen()
            Dim configStylesZones As New List(Of ConfigStylesZone)
            configStylesZones.Add(New ConfigStylesZone("Flag", LocalizableOpen._0111, LocalizableOpen._0112))

            Update()

            MyBase.OnOpen(configStylesZones)
        End Sub

        Protected Overrides Sub OnPageBeforeRender(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            AddRewriteServerQueryString(mode)
            MyBase.OnPageBeforeRender(mode)
        End Sub

        Protected Overrides Sub OnPageInit()
            UpdateLinkFlag()
            MyBase.OnPageInit()
        End Sub

        Protected Overrides Sub Render(ByVal writer As HtmlWriter)
            MyBase.RenderBeginTag(writer)

            For Each configLanguage As WEConfigLanguage In Me.ListConfigLanguage

                Dim pageLanguage As Language = configLanguage.PageLanguage
                If pageLanguage Is Nothing Then Continue For
                If Not Me.Page.IsVisiblePerLanguage(pageLanguage.TrueCode) Then Continue For
                If Not configLanguage.Visible Then Continue For
                Dim flagLink As Link = configLanguage.FlagLink
                Dim url As String
                Dim current As String

                If Me.Page.RenderSubMode = openElement.WebElement.Page.EnuTypeRenderSubMode.Upload Then
                    current = Me.Page.GetHtmlFileName(pageLanguage.Code, True, True)
                Else
                    current = Me.Page.GetHtmlFileName(pageLanguage.Code, False, False)
                End If

                If flagLink.IsEmpty("DEFAULT") Then
                    If String.IsNullOrEmpty(pageLanguage.Domain) Then
                        url = Page.CreateRelativeLink(current)
                    Else
                        url = String.Concat("http://", pageLanguage.Domain, "/", current)
                    End If
                Else
                    url = MyBase.GetLink(flagLink, "DEFAULT")
                End If

                If Me.Page.RenderMode = openElement.WebElement.Page.EnuTypeRenderMode.Export _
                And Me.Page.RenderSubMode = openElement.WebElement.Page.EnuTypeRenderSubMode.Upload Then
                    Select Case Me.Page.ServerSiteScripting
                        Case openElement.WebElement.Page.EnuServerSiteScripting.Php
                            url = String.Concat("<?php echo addCurrentURLParams('", url, "'); ?>")
                    End Select
                End If

                Dim imageSrc As String
                If configLanguage.Image.IsEmpty Then
                    imageSrc = MyBase.GetLink(configLanguage.ImageAuto, "DEFAULT")
                Else
                    imageSrc = MyBase.GetLink(configLanguage.Image, "DEFAULT")
                End If

                Dim isCurrentCulture = Me.Page.Culture.Equals(pageLanguage.Code)

                writer.WriteBeginTag("div")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Flag"))
                writer.Write(HtmlTextWriter.TagRightChar)
                If Not isCurrentCulture Then
                    writer.WriteBeginTag("a")
                    writer.WriteAttribute("href", url)
                    writer.WriteAttribute("rel", "alternate")
                    writer.WriteAttribute("hreflang", pageLanguage.TrueCode)
                    writer.Write(HtmlTextWriter.TagRightChar)
                End If

                If Not ViewType = EnuViewType.OnlyText Then
                    writer.WriteBeginTag("img")
                    writer.WriteAttribute("style", "border:none;vertical-align:bottom")
                    writer.WriteAttribute("src", imageSrc)
                    writer.WriteAttribute("alt", pageLanguage.Name)
                    writer.Write(HtmlTextWriter.SelfClosingTagEnd)
                End If

                If Not ViewType = EnuViewType.OnlyFlag Then
                    writer.Write(pageLanguage.Name)
                End If

                If Not isCurrentCulture Then
                    writer.WriteEndTag("a")
                End If
                writer.WriteEndTag("div")
                writer.WriteLine()

            Next

            MyBase.RenderEndTag(writer)
        End Sub

        Private Sub AddRewriteServerQueryString(ByVal mode As openElement.WebElement.Page.EnuTypeRenderMode)
            If mode = openElement.WebElement.Page.EnuTypeRenderMode.Export _
            And Me.Page.RenderSubMode = openElement.WebElement.Page.EnuTypeRenderSubMode.Upload Then

                Select Case Me.Page.ServerSiteScripting

                    Case openElement.WebElement.Page.EnuServerSiteScripting.Php

                        Dim script As New StringBuilder
                        script.AppendLine("function addCurrentURLParams($newURL) {")
                        script.AppendLine(" $currURL = $_SERVER['REQUEST_URI'];")
                        script.AppendLine(" if (!$newURL || !$currURL) return $newURL;")
                        script.AppendLine(" $pos = strpos($currURL, '?'); if (!$pos) return $newURL; // no parameters")
                        script.AppendLine(" $params = substr($currURL, $pos);")
                        script.AppendLine(" return $newURL.$params;")
                        script.AppendLine("}")

                        Dim scriptBlock As New ScriptBlock("RewriteQueryString", EnuScriptType.Php, EnuScriptPosition.StartDocument)
                        scriptBlock.Code.SetValue(script.ToString)
                        MyBase.AddBlockScripts(scriptBlock)

                End Select

            End If
        End Sub

        ''' <summary>
        ''' Configlanguage update
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Update()
            If MyBase.NumUpdate = 0 Then
                For Each item In ListConfigLanguage
                    item.ParentElement = Me
                Next
                MyBase.NumUpdate = 1
            End If
        End Sub

        ''' <summary>
        ''' Update of the list of flag's image link (when adding language)
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdateLinkFlag()
            Dim list As ListOfLanguage = Various.GetListLanguage
            If list IsNot Nothing Then
                'update list
                For Each lang As Language In list.ListOfActiveLanguage
                    Dim exist As Boolean = False
                    For Each configLanguage As WEConfigLanguage In ListConfigLanguage
                        If exist OrElse lang.TrueCode.Equals(configLanguage.TrueCode) Then
                            exist = True
                            Exit For
                        End If
                    Next
                    If Not exist Then ListConfigLanguage.Add(New WEConfigLanguage(Me, lang.TrueCode))
                Next
            End If
        End Sub

        #End Region 'Methods

    End Class

End Namespace

