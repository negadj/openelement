Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement
Imports openElement.WebSite.Config
Imports System.Text
Imports openElement.WebElement.LinksManager

Namespace Elements.Navigate

    <Serializable()> _
    Public Class WEFlag
        Inherits ElementBase

        <Common.Attributes.ContainsLinks()> _
         Private _ListConfigLanguage As List(Of openElement.WebElement.DataType.WEConfigLanguage)
        Private _ViewType As EnuViewType

        Public Enum EnuViewType As Short
            OnlyFlag = 0
            OnlyText = 1
            FlagAndText = 2
        End Enum

        <NonSerialized(), Obsolete(), Common.Attributes.OEObsolete(1, 32)> Private _ListEOLanguage As List(Of Language)

#Region "Properties"

        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N237"), _
        Ressource.localizable.LocalizableDescAtt("_D237"), _
        Editor(GetType(Editors.UITypeListConfigLanguage), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ListConfigLanguage() As List(Of openElement.WebElement.DataType.WEConfigLanguage)
            Get
                If _ListConfigLanguage Is Nothing Then
                    _ListConfigLanguage = New List(Of openElement.WebElement.DataType.WEConfigLanguage)
                End If

                Return _ListConfigLanguage
            End Get
            Set(ByVal value As List(Of openElement.WebElement.DataType.WEConfigLanguage))
                _ListConfigLanguage = value
            End Set
        End Property


        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N237"), _
        Ressource.localizable.LocalizableDescAtt("_D237"), _
        Editor(GetType(Editors.UITypeFlagView), GetType(Drawing.Design.UITypeEditor)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ViewType() As EnuViewType
            Get
                Return _ViewType
            End Get
            Set(ByVal value As EnuViewType)
                _ViewType = value
            End Set
        End Property

#End Region

#Region "Builder required function"

        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEFlag", page, parentID, templateName)
            MyBase.TypeResize = EnuTypeResize.None
            UpdateLinkFlag()
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0109
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupNavigate"
            info.ToolBoxIco = My.Resources.WEFlag
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0110
            info.SortPropertyList.Add(New SortProperty("ListConfigLanguage", "tools.png", My.Resources.text.LocalizableOpen._0030))
            Return info

        End Function

        Protected Overrides Sub OnOpen()

            Dim configStylesZones As New List(Of StylesManager.ConfigStylesZone)
            configStylesZones.Add(New StylesManager.ConfigStylesZone("Flag", My.Resources.text.LocalizableOpen._0111, My.Resources.text.LocalizableOpen._0112))

            Update()

            MyBase.OnOpen(configStylesZones)
        End Sub


        Protected Overrides Sub OnPageInit()
            UpdateLinkFlag()
            MyBase.OnPageInit()
        End Sub

        Protected Overrides Sub OnPageBeforeRender(ByVal mode As Page.EnuTypeRenderMode)
            AddRewriteServerQueryString(mode)
            MyBase.OnPageBeforeRender(mode)
        End Sub

#End Region

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
            Dim list As ListOfLanguage = Tools.Various.GetListLanguage
            If list IsNot Nothing Then
                'update list
                For Each lang As Language In list.ListOfActiveLanguage
                    Dim exist As Boolean = False
                    For Each configLanguage As DataType.WEConfigLanguage In ListConfigLanguage
                        If exist OrElse lang.TrueCode.Equals(configLanguage.TrueCode) Then
                            exist = True
                            Exit For
                        End If
                    Next
                    If Not exist Then ListConfigLanguage.Add(New WEConfigLanguage(Me, lang.TrueCode))
                Next
            End If

        End Sub

        Private Sub AddRewriteServerQueryString(ByVal mode As Page.EnuTypeRenderMode)

            If mode = Page.EnuTypeRenderMode.Export _
            And Me.Page.RenderSubMode = Page.EnuTypeRenderSubMode.Upload Then

                Select Case Me.Page.ServerSiteScripting

                    Case Page.EnuServerSiteScripting.Php

                        Dim script As New StringBuilder
                        script.AppendLine("function addCurrentURLParams($newURL) {")
                        script.AppendLine(" $currURL = $_SERVER['REQUEST_URI'];")
                        script.AppendLine(" if (!$newURL || !$currURL) return $newURL;")
                        script.AppendLine(" $pos = strpos($currURL, '?'); if (!$pos) return $newURL; // no parameters")
                        script.AppendLine(" $params = substr($currURL, $pos);")
                        script.AppendLine(" return $newURL.$params;")
                        script.AppendLine("}")

                        Dim scriptBlock As New Common.ScriptBlock("RewriteQueryString", Common.EnuScriptType.Php, Common.EnuScriptPosition.StartDocument)
                        scriptBlock.Code.SetValue(script.ToString)
                        MyBase.AddBlockScripts(scriptBlock)

                    Case Else

                End Select

            End If

        End Sub
 
#Region "Render"


        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            MyBase.RenderBeginTag(writer)


            For Each configLanguage As WEConfigLanguage In Me.ListConfigLanguage

                Dim pageLanguage As Language = configLanguage.PageLanguage
                If pageLanguage Is Nothing Then Continue For
                If Not Me.Page.IsVisiblePerLanguage(pageLanguage.TrueCode) Then Continue For
                If Not configLanguage.Visible Then Continue For
                Dim flagLink As Link = configLanguage.FlagLink
                Dim url As String
                Dim current As String

                If Me.Page.RenderSubMode = Page.EnuTypeRenderSubMode.Upload Then
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

                If Me.Page.RenderMode = Page.EnuTypeRenderMode.Export _
                And Me.Page.RenderSubMode = Page.EnuTypeRenderSubMode.Upload Then
                    Select Case Me.Page.ServerSiteScripting
                        Case Page.EnuServerSiteScripting.Php
                            url = String.Concat("<?php echo addCurrentURLParams('", url, "'); ?>")
                    End Select
                End If

                Dim imageSrc As String
                If configLanguage.Image.IsEmpty Then
                    imageSrc = MyBase.GetLink(configLanguage.ImageAuto, "DEFAULT")
                Else
                    imageSrc = MyBase.GetLink(configLanguage.Image, "DEFAULT")
                End If

                Dim isCurrentCulture As Boolean = False
                If Me.Page.Culture.Equals(pageLanguage.Code) Then
                    isCurrentCulture = True
                End If

                writer.WriteBeginTag("div")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass("Flag"))
                writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                If Not isCurrentCulture Then
                    writer.WriteBeginTag("a")
                    writer.WriteAttribute("href", url)
                    writer.WriteAttribute("rel", "alternate")
                    writer.WriteAttribute("hreflang", pageLanguage.TrueCode)
                    writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                End If

                If Not ViewType = EnuViewType.OnlyText Then
                    writer.WriteBeginTag("img")
                    writer.WriteAttribute("style", "border:none;vertical-align:bottom")
                    writer.WriteAttribute("src", imageSrc)
                    writer.WriteAttribute("alt", pageLanguage.Name)
                    writer.Write(Web.UI.HtmlTextWriter.SelfClosingTagEnd)
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
#End Region


    End Class




End Namespace
