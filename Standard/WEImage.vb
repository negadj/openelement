Imports System.ComponentModel
Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports openElement

'Namespace de l'élément (Créer le votre ex : Elements.MyCompagny)
Namespace Elements.Standard

    ''' <summary>
    ''' L'élément présenté ci-dessous est la copie conforme du code source de l'élément Image disponible dans openElement
    ''' Créer une Class Public qui hérite de "openElement.WebElement.Elements.ElementBase".
    ''' Voir la documentation se rapportant à ElementBase pour toutes les explications des fonctions de mybase utilisé dans cette classe.
    ''' Le nom de la class est primordial il doit être unique pour le même Namespace et ne pourra plus être modifié par la suite.
    ''' Il est indispensable d'indiquer cette Class comme sérializable.
    ''' </summary>
    ''' <remarks>Il est préférable de nous soumettre le nom</remarks>
    <Serializable()> _
    Public Class WEImage
        Inherits ElementBase

#Region "Propriétés"
        'Pour les métaTags des propriétés publiques, se rapporter au chapitre concerné

        ''' <summary>
        ''' Contient les différents chemins de l'image d'origine en fonction de la culture de la page
        ''' </summary>
        ''' <remarks></remarks>
        Private _ImageLink As LinksManager.Link
        ''' <summary>
        ''' Contient les différents chemins de l'image redimensionnée (si besoin) en fonction de la culture de la page 
        ''' </summary>
        ''' <remarks></remarks>
        Private _ImageResizeLink As LinksManager.Link
        ''' <summary>
        ''' Contient les différents liens en fonction de la culture, de l'image sur une action de click. 
        ''' </summary>
        ''' <remarks></remarks>
        Private _PageLink As LinksManager.Link
        ''' <summary>
        ''' Texte alternatif de l'image. Ne s'affiche que si le chemin vers l'image n'est plus valide.
        ''' </summary>
        ''' <remarks></remarks>
        Private _AlternateText As DataType.LocalizableString
        ''' <summary>
        ''' Renseigne si c'est le chemin de l'image d'origine (valeur true) qui est utilisé ou celui de l'image redimensionnée(valeur false). 
        ''' </summary>
        ''' <remarks>Cette valeur est modifiée automatiquement par redimensionnement manuel de l'utilisateur et peut être modifié manuellement par celui ci dans les propriétés.</remarks>
        Private _DefaultImage As Boolean
        ''' <summary>
        ''' Dimension de l'image dans la page html.
        ''' </summary>
        ''' <remarks></remarks>
        Private _ImageSize As Drawing.Size


        <NonSerialized()> Private _LockResizeEvent As Boolean



        ''' <summary>
        ''' Propriété de la variable _DefaultImage
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Appearance), _
        Ressource.localizable.LocalizableNameAtt("_N093"), _
        Ressource.localizable.LocalizableDescAtt("_D094"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Protected Friend Property DefaultImage() As Boolean
            Get
                Return _DefaultImage
            End Get
            Set(ByVal value As Boolean)
                _DefaultImage = value
                If _DefaultImage Then
                    _ImageResizeLink = Nothing
                End If
            End Set
        End Property

        ''' <summary>
        ''' Propriété de la variable _ImageLink
        ''' </summary>
        ''' <remarks>Cette valeur ne peut jamais être à nothing</remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N002"), _
        Ressource.localizable.LocalizableDescAtt("_D002"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkFile), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.ElementWithCss), _
        Common.Attributes.ConfigBiblio(True, False, False, False, False)> _
        Public Property ImageLink() As LinksManager.Link
            Get
                If _ImageLink Is Nothing Then
                    _ImageLink = New LinksManager.Link()
                End If
                If DefaultImage Then _ImageLink.BannedFromUpload = False Else _ImageLink.BannedFromUpload = True
                Return _ImageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _ImageLink = value
                SetDefaultSize()
            End Set
        End Property

        ''' <summary>
        ''' Propriété de la variable _ImageResizeLink
        ''' </summary>
        <Browsable(False)> _
        Public Property ImageResizeLink() As LinksManager.Link
            Get
                If _ImageResizeLink Is Nothing Then
                    _ImageResizeLink = New LinksManager.Link()
                End If
                If DefaultImage Then _ImageResizeLink.BannedFromUpload = True Else _ImageResizeLink.BannedFromUpload = False
                Return _ImageResizeLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _ImageResizeLink = value
            End Set
        End Property

        ''' <summary>
        ''' Propriété de la variable _PageLink
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N003"), _
        Ressource.localizable.LocalizableDescAtt("_D003"), _
        Editor(GetType(openElement.WebElement.Editors.UITypeLinkPage), GetType(Drawing.Design.UITypeEditor)), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLinkFile)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property PageLink() As LinksManager.Link
            Get
                If _PageLink Is Nothing Then _PageLink = New LinksManager.Link()
                Return _PageLink
            End Get
            Set(ByVal value As LinksManager.Link)
                _PageLink = value
            End Set
        End Property

        ''' <summary>
        ''' Propriété de la variable _AlternateText
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Edition), _
        Ressource.localizable.LocalizableNameAtt("_N004"), _
        Ressource.localizable.LocalizableDescAtt("_D004"), _
        TypeConverter(GetType(openElement.WebElement.Editors.Converter.TConvLocalizableString)), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property AlternateText() As DataType.LocalizableString
            Get


                If _AlternateText Is Nothing Then
                    _AlternateText = New DataType.LocalizableString("")
                End If
                Return _AlternateText
            End Get
            Set(ByVal value As DataType.LocalizableString)
                _AlternateText = Tools.WebElem.PropertiesLocalizableStringFormat(value, MyBase.Page.Culture, Tools.Enu.ProgLanguage.Html)
            End Set
        End Property

#End Region

#Region "Construction"

        ''' <summary>
        ''' Le constructeur doit avoir obligatoirement la forme suivante et faire appel au constructeur de la classe hérité
        ''' Pour les paramètres du contructeur de base, se rapporter à la classe correspondante
        ''' </summary>
        ''' <param name="page">Référence à la page dans lequel est positionné l'élément(attribuer automatiquement)</param>
        ''' <param name="parentID">Identifiant du conteneur parent(attribuer automatiquement)</param>
        ''' <param name="templateName">Nom du template direct dans lequel est contenu l'élément(attribuer automatiquement)</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal page As Page, ByVal parentID As String, ByVal templateName As String)
            MyBase.New(EnuElementType.PageEdit, "WEImage", page, parentID, templateName)
            MyBase.NumUpdate = 1
            Me.DefaultImage = True
        End Sub

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            'Nom de l'élément affiché dans la liste des éléments
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0007 'Image
            'Description de l'élément
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0008 '  "Ajouter une image de la bibliothèque de ressource."
            'Numéro de version majeur de l'élément
            info.VersionMajor = 1
            'Numéro de version mineur de l'élément
            info.VersionMinor = 0
            'Groupe de la barre d'outils d'openElement (NBGroupStandard,)
            info.GroupName = "NBGroupStandard"
            'Icone pour la barre d'outils d'openElement (Taille 16x16) 
            info.ToolBoxIco = My.Resources.WEImage
            'Propriété à ouvrir automatiquement lors de l'ajout de l'élément dans la page
            info.AutoOpenProperty = "ImageLink"

            'Pour rajouter des propriétés dans la liste des acces rapides (icones qui s'affiche en dessous de l'élément lors de sa sélection): 
            'Ajouter à la liste un nouvel objet SortProperty 
            '(paramètres : nom de la propriété, nom de l'image associé (celle ci est placé dans le dossier ressource du projet), Texte du tooltip associé)
            info.SortPropertyList.Add(New SortProperty("ImageLink", "folder.png", My.Resources.text.LocalizableOpen._0009)) ' "Sélection de l'image Principale"))
            info.SortPropertyList.Add(New SortProperty("PageLink", "link.png", My.Resources.text.LocalizableOpen._0010)) ' "Sélection du lien principal"))
            Return info

        End Function

        ''' <summary>
        ''' Evènement de démarrage (OnOpen) obligatoire pour la configuration de l'élément
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnOpen()



            'A placer obligatoirement à la fin
            MyBase.OnOpen()

        End Sub


#End Region

#Region "Render"
        'Région consacré au rendu html sur la page internet de l'objet 'image' (obligatoire pour les éléments de type EnuElementType.PageEdit).

        ''' <summary>
        ''' Surcharge de l'evénemenent déclenché avant l'ecriture du rendu de la page  
        ''' Ne pas oublier l'appel à l'évenement correspondant de la classe hérité
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageBeforeRender(ByVal mode As Page.EnuTypeRenderMode)

            MyBase.OnPageBeforeRender(mode)
        End Sub


        Protected Overrides Sub OnPageInit()
            If MyBase.NumUpdate = 0 Then
                CreateImageResizeLink()
                MyBase.NumUpdate = 1
            End If
            MyBase.OnPageInit()
        End Sub


        ''' <summary>
        ''' Surcharge de l'événement déclenché après l'écriture du rendu de la page
        ''' Ne pas oublier l'appel à l'évenement correspondant de la classe hérité
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnResizeEnd()
            If _LockResizeEvent Then Exit Sub
            CreateImageResizeLink()
            MyBase.LiveUpdateHtmlProperty("img", "src", GetStrImageLink)
            MyBase.OnResizeEnd()
        End Sub

        Protected Overrides Sub OnTypeResizeChange(ByVal oldType As EnuTypeResize, ByRef newType As EnuTypeResize)
            _LockResizeEvent = True
            If String.IsNullOrEmpty(MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value) Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value = _ImageSize.Width
            End If
            If String.IsNullOrEmpty(MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value) Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value = _ImageSize.Height
            End If
            _LockResizeEvent = False
            MyBase.OnTypeResizeChange(oldType, newType)
        End Sub

        ''' <summary>
        ''' Fonction de construction des propriétés css directement dans le tag de l'image
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetImageStyle() As String

            Dim builder As New Text.StringBuilder()

            If MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Auto Then
                builder.Append(String.Concat("height:", _ImageSize.Height, "px;"))
            Else
                If _ImageSize.Height > 0 And _ImageSize.Height < 15 Then
                    Dim prop As Integer = Math.Round((100 * _ImageSize.Height) / 15, 0)
                    builder.Append(String.Concat("height:", prop, "%;"))
                End If
            End If

            If MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Auto Then
                builder.Append(String.Concat("width:", _ImageSize.Width, "px;"))
            Else
                If _ImageSize.Width > 0 And _ImageSize.Width < 15 Then
                    Dim prop As Integer = Math.Round((100 * _ImageSize.Width) / 15, 0)
                    builder.Append(String.Concat("width:", prop, "%;"))
                End If
            End If

            Return builder.ToString

        End Function


        ''' <summary>
        ''' Récupération du lien de l'image (originel ou redimensionné)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetStrImageLink() As String

            If Me.DefaultImage Then
                Return MyBase.GetLink(Me.ImageLink)
            Else
                Return MyBase.GetLink(Me.ImageResizeLink)
            End If

        End Function


        ''' <summary>
        ''' Evènement de rendu (obligatoire pour les éléments de type EnuElementType.PageEdit).
        ''' C'est ici que la création de l'HTML de l'élément se construit.
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)

            Dim strPageLink As String = MyBase.GetLink(Me.PageLink)
            Dim strImageLink As String = GetStrImageLink()

            'A ajouter obligatoirement en début du rendu html de l'élement
            MyBase.RenderBeginTag(writer)

            'Code html spécifique de l'image 
            If Not String.IsNullOrEmpty(strPageLink) Then
                writer.WriteBeginTag("a")
                writer.WriteHrefAttribute(Me, Me.PageLink, True)
                writer.Write(System.Web.UI.HtmlTextWriter.TagRightChar)
            End If

            If Not String.IsNullOrEmpty(strImageLink) Then
                writer.WriteBeginTag("img")
                writer.WriteAttribute("style", GetImageStyle())
                writer.WriteAttribute("src", strImageLink)
                writer.WriteAttribute("alt", Me.AlternateText.GetValue(MyBase.Page.Culture))
                writer.Write(System.Web.UI.HtmlTextWriter.SelfClosingTagEnd)
            End If

            If Not String.IsNullOrEmpty(strPageLink) Then
                writer.WriteEndTag("a")
            End If

            'A ajouter obligatoirement en fin du rendu html de l'élement
            MyBase.RenderEndTag(writer)

        End Sub

#End Region


        Private Sub UpdateMinMaxSize()

            If MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Auto Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.MinHeight.SetCss(_ImageSize.Height)
                MyBase.StylesSkin.BaseDiv.BaseStyles.MaxHeight.SetCss(_ImageSize.Height)
            Else
                MyBase.StylesSkin.BaseDiv.BaseStyles.MinHeight.SetCss("")
                MyBase.StylesSkin.BaseDiv.BaseStyles.MaxHeight.SetCss("")
            End If

            If MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Auto Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.MinWidth.SetCss(_ImageSize.Width)
                MyBase.StylesSkin.BaseDiv.BaseStyles.MaxWidth.SetCss(_ImageSize.Width)
            Else
                MyBase.StylesSkin.BaseDiv.BaseStyles.MinWidth.SetCss("")
                MyBase.StylesSkin.BaseDiv.BaseStyles.MaxWidth.SetCss("")
            End If

        End Sub

        ''' <summary>
        ''' Détermine si la taille de l'image utilisé est conforme au taille minimum fixé
        ''' Cette taille minimum est necessaire pour permette la selection de l'élément dans l'éditeur par un clic de souris
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetDefaultSize()

            Dim imgSrc = MyBase.GetLinkIOPath(Me.ImageLink)
            If String.IsNullOrEmpty(imgSrc) Then _ImageSize = New Drawing.Size(15, 15) : Exit Sub

            'Get bitmap size
            Dim originBitmap As OBitmap = MyBase.OpenBitmap(imgSrc)
            If originBitmap.Bitmap Is Nothing Then Exit Sub
            _ImageSize = originBitmap.Bitmap.Size
            MyBase.CloseBitmap(originBitmap)

            'taille minimum de l'image fixé à 15px de largeur
            If _ImageSize.Width < 15 Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.Width.SetCss(15)
            Else
                MyBase.StylesSkin.BaseDiv.BaseStyles.Width.SetCss(_ImageSize.Width)
            End If

            'et 15 px de hauteur
            If _ImageSize.Height < 15 Then
                MyBase.StylesSkin.BaseDiv.BaseStyles.Height.SetCss(15)
            Else
                MyBase.StylesSkin.BaseDiv.BaseStyles.Height.SetCss(_ImageSize.Height)
            End If


        End Sub

        ''' <summary>
        ''' Fonction qui détermine si l'image doit être redimensionné
        ''' Cela se décide en fonction des dimensions de l'image d'origine et des dimensions de l'image sur la page
        ''' Cela permet de diminuer suivant les cas de considérablement la taille de l'image
        ''' et par conséquence celle de la page à charger dans le navigateur
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CreateImageResizeLink()

            If _ImageLink Is Nothing Then Exit Sub

            Try

                _LockResizeEvent = True

                Dim originFullPath As String = MyBase.GetLinkIOPath(Me.ImageLink)
                If String.IsNullOrEmpty(originFullPath) Then Exit Sub

                Dim imageFormat As Drawing.Imaging.ImageFormat = Tools.Picture.ImageFormatByExt(IO.Path.GetExtension(originFullPath))
                If imageFormat.Equals(Drawing.Imaging.ImageFormat.Gif) Then
                    Me.DefaultImage = True
                    Exit Sub
                End If

                Dim originBitmap As OBitmap = MyBase.OpenBitmap(originFullPath)
                If originBitmap Is Nothing OrElse originBitmap.Bitmap Is Nothing Then ' originBitmap Is Nothing may happen (= happened for one of user projects) on project upgrade (becomes important as we now may call this function on PageInit
                    Exit Sub
                End If

                Dim originWidth As Integer = originBitmap.Bitmap.Width
                Dim originHeight As Integer = originBitmap.Bitmap.Height
                Dim newWidth As String = MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value
                Dim newHeight As String = MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value

                If MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Auto Or String.IsNullOrEmpty(newWidth) Then
                    newWidth = originWidth
                    MyBase.StylesSkin.BaseDiv.BaseStyles.Width.Value = originWidth
                End If

                If MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Auto Or String.IsNullOrEmpty(newHeight) Then
                    newHeight = originHeight
                    MyBase.StylesSkin.BaseDiv.BaseStyles.Height.Value = originHeight
                End If


                If originWidth = newWidth And originHeight = newHeight Then
                    Me.DefaultImage = True
                    If MyBase.NumUpdate = 0 Then
                        MyBase.TypeResize = EnuTypeResize.None
                    End If
                Else

                    For Each culture As String In ImageLink.GetListSitePath().Keys

                        Dim fullCulturePath As String = MyBase.GetLinkIOPath(Me.ImageLink, culture)

                        Dim cultureBitmap As OBitmap = MyBase.OpenBitmap(fullCulturePath)
                        cultureBitmap.Resize(New Drawing.Size(newWidth, newHeight))

                        Dim linkPath As String = String.Concat("WEFiles/Image/WEImage/", Me.ImageResizeLink.ID, culture, IO.Path.GetExtension(fullCulturePath))
                        MyBase.CreateAutoRessourceByBitmap(Me.ImageResizeLink, LinksManager.Link.EnuLinkType.ElementImage, cultureBitmap.Bitmap, linkPath, culture)

                        MyBase.CloseBitmap(cultureBitmap)

                    Next

                    Me.DefaultImage = False

                    If MyBase.NumUpdate = 0 Then

                        If Not originWidth = newWidth And Not originHeight = newHeight Then
                            MyBase.TypeResize = EnuTypeResize.Both
                        ElseIf Not originWidth = newWidth Then
                            MyBase.TypeResize = EnuTypeResize.Width
                        ElseIf Not originHeight = newHeight Then
                            MyBase.TypeResize = EnuTypeResize.Height
                        End If

                    End If


                End If

                Me.SelectLinkToUpload()

                MyBase.CloseBitmap(originBitmap)


            Catch ex As Exception
                OEBug.Capture(ex, True, True)
            Finally
                UpdateMinMaxSize()
                _LockResizeEvent = False
            End Try

        End Sub


        ''' <summary>
        ''' Determine quelle ressource (image d'origine ou redimmentionnée) sera mise en ligne
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SelectLinkToUpload()
            If Me.DefaultImage Then
                Me.ImageLink.BannedFromUpload = False
                Me.ImageResizeLink.BannedFromUpload = True
            Else
                Me.ImageLink.BannedFromUpload = True
                Me.ImageResizeLink.BannedFromUpload = False
            End If
        End Sub


#Region "DD Translation of LocalizableStrings"

        ' See comments in ElementBase class
        Public Overrides Function GetLocalizableStringsForTranslationSystem( _
                                        ByVal accListLS As Dictionary(Of String, DataType.LocalizableString), _
                                        ByVal accListInfo As Dictionary(Of String, String), _
                                        Optional ByVal onlyNonEmpty As Boolean = True) As Boolean
            If accListLS Is Nothing Or accListInfo Is Nothing Then Return False

            If _AlternateText Is Nothing OrElse (onlyNonEmpty AndAlso _AlternateText.IsEmpty) Then Return False

            Dim lsID As String = "WEImage." & ID & ".AltText"
            accListLS(lsID) = _AlternateText

            If Not String.IsNullOrEmpty(Me.Name) Then
                accListInfo(lsID) = "Element name: " & Me.Name & " (Image)"
            End If

            Return True
        End Function

#End Region


    End Class

End Namespace
