
Imports openElement.WebElement.Elements
Imports openElement.WebElement
Imports System.ComponentModel
Imports openElement.WebElement.DataType


Namespace WEElements.Standard


    <Serializable()> _
Public Class WETable
        Inherits ElementBase

        Private _NbRow As Integer
        Private _NbCol As Integer

        <Common.Attributes.ContainsLinks()> _
        Private _Table As WETableData
        Private _ActiveRow As Integer
        Private _ActiveCol As Integer
        Private _AddRow As Boolean
        Private _Informer As Boolean
        Private _NotEditable As Boolean

        <NonSerialized()> _
        Private _ConfigStylesZones As List(Of StylesManager.ConfigStylesZone)

#Region "Proprietes"
        ''' <summary>
        ''' Nombre de ligne
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property NbRow() As Integer
            Get
                Return _NbRow
            End Get
            Set(ByVal value As Integer)
                _NbRow = value
            End Set
        End Property

        ''' <summary>
        ''' Nombre de colonnes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property NbCol() As Integer
            Get
                Return _NbCol
            End Get
            Set(ByVal value As Integer)
                _NbCol = value
            End Set
        End Property

        ''' <summary>
        ''' Données du tableau
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property Table() As WETableData
            Get
                If _Table Is Nothing Then _Table = New WETableData(NbRow, NbCol)
                Return _Table
            End Get
            Set(ByVal value As WETableData)
                _Table = value
            End Set
        End Property

        ''' <summary>
        ''' Proprietes permettant la sauvegarde des donnes saisie par l'utilisateur dans l'éditeur
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property Cell(ByVal Row As Object, ByVal Col As Object)
            Get
                Return (Table.GetLocalizableHtml(Integer.Parse(Row), Integer.Parse(Col)))
            End Get
            Set(ByVal value)
                Table.SetValue(Row, Col, value)
            End Set
        End Property

        ''' <summary>
        ''' Affiche les indicateurs de lignes et de colonnes en mode editable
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.EditMode), _
       Ressource.localizable.LocalizableNameAtt("_N199"), _
       Ressource.localizable.LocalizableDescAtt("_D199"), _
       openElement.WebElement.Common.Attributes.PageUpdateMode(openElement.WebElement.Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
       Public Property Informer() As Boolean
            Get
                If MyBase.Page.RenderMode <> openElement.WebElement.Page.EnuTypeRenderMode.Editor Then Return False
                Return _Informer

            End Get
            Set(ByVal value As Boolean)
                _Informer = value
            End Set
        End Property

        ''' <summary>
        ''' Non serialisé
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <Browsable(False)> _
        Public Property ConfigStylesZones() As List(Of StylesManager.ConfigStylesZone)
            Get
                If _ConfigStylesZones Is Nothing Then _ConfigStylesZones = New List(Of StylesManager.ConfigStylesZone)
                Return _ConfigStylesZones
            End Get
            Set(ByVal value As List(Of StylesManager.ConfigStylesZone))
                _ConfigStylesZones = value
            End Set
        End Property

        ''' <summary>
        ''' Blocage du mode éditable
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.EditMode), _
        Ressource.localizable.LocalizableNameAtt("_N201"), _
        Ressource.localizable.LocalizableDescAtt("_D201"), _
        openElement.WebElement.Common.Attributes.PageUpdateMode(openElement.WebElement.Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property NotEditable() As Boolean
            Get
                Return _NotEditable
            End Get
            Set(ByVal value As Boolean)
                _NotEditable = value
            End Set
        End Property

#End Region

#Region "Proprietes d'actions"

        ''' <summary>
        ''' Change le nombre de ligne du tableau
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N198"), _
        Ressource.localizable.LocalizableDescAtt("_D198"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ActNbRow() As Integer
            Get
                Return NbRow
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then value = 1
                Call ChangeNbRow(value)
            End Set
        End Property

        ''' <summary>
        ''' Change le nombre de colonne du tableau
        ''' </summary>
        <Ressource.localizable.LocalizableCatAtt(Ressource.localizable.LocalizableCatAtt.EnumWECategory.Behavior), _
        Ressource.localizable.LocalizableNameAtt("_N197"), _
        Ressource.localizable.LocalizableDescAtt("_D197"), _
        Common.Attributes.PageUpdateMode(Common.Attributes.PageUpdateMode.EnuUpdateMode.Element)> _
        Public Property ActNbCol() As Integer
            Get
                Return NbCol
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then value = 1
                Call ChangeNbColumn(value)
            End Set
        End Property




        Protected Overrides Function OnShortActionUpdateMode(ByVal actionName As String) As Common.Attributes.PageUpdateMode.EnuUpdateMode
            Return Common.Attributes.PageUpdateMode.EnuUpdateMode.Element
        End Function




        Protected Overrides Sub OnShortAction(ByVal actionName As String)

            Select Case actionName
                Case "ActInsertCellStylesZone"
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(My.Resources.text.LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Call AddCellStyleZone(_ActiveRow, _ActiveCol)
                    openElement.Tools.WebElem.ChangeSelectedStylesZone(Me.ID, CreateCellStyleName(_ActiveRow, _ActiveCol))
                Case "ActAddRow"
                    AddRow()
                Case "ActAddColumn"
                    AddColumn()
                Case "ActDeleteRow"
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(My.Resources.text.LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Dim answer As MsgBoxReturn = OEMsgBox(String.Format(My.Resources.text.LocalizableOpen._0355, _ActiveRow), MsgBoxType.Question_YesNo) 'Souhaitez vous supprimer la ligne {0}
                    If answer <> MsgBoxReturn.Yes Then Exit Sub
                    DeleteRow(_ActiveRow)
                Case "ActDeleteRow" 'Action Suppression d'une ligne
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(My.Resources.text.LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Dim answer As MsgBoxReturn = OEMsgBox(String.Format(My.Resources.text.LocalizableOpen._0355, _ActiveRow), MsgBoxType.Question_YesNo) 'Souhaitez vous supprimer la ligne {0}
                    If answer <> MsgBoxReturn.Yes Then Exit Sub
                    DeleteRow(_ActiveRow)
                Case "ActDeleteColumn" 'Action Suppression d'une colonne
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(My.Resources.text.LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Dim answer As MsgBoxReturn = OEMsgBox(String.Format(My.Resources.text.LocalizableOpen._0356, _ActiveCol), MsgBoxType.Question_YesNo) 'Souhaitez vous supprimer la colonne {0}
                    If answer <> MsgBoxReturn.Yes Then Exit Sub
                    Call DeleteColumn(_ActiveCol)
                Case "ActInsertRow" 'Action insertion d'une ligne
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(My.Resources.text.LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Call InsertRow(_ActiveRow)
                    Me.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Normal).Height.Auto = True
                Case "ActInsertColumn" 'Action insertion d'une colonne
                    If Not GetActiveCell() OrElse _ActiveRow < 0 Then OEMsgBox(My.Resources.text.LocalizableOpen._0354, MsgBoxType.Info) : Exit Sub '"Veuillez selectionner une cellule du tableau."
                    Call InsertColumn(_ActiveCol)
                    Me.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Normal).Width.Auto = True
            End Select

        End Sub


#End Region


#Region "Constructeur"
        ''' <summary>
        ''' Constructeur
        ''' </summary>
        ''' <param name="Page"></param>
        ''' <param name="ParentID"></param>
        ''' <param name="TemplateName"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Page As Page, ByVal ParentID As String, ByVal TemplateName As String)
            MyBase.New(EnuElementType.PageEdit, "WETable", Page, ParentID, TemplateName)
            MyBase.TypeResize = EnuTypeResize.None

            NbCol = 2
            NbRow = 2
            Me.NumUpdate = 1
            InitStyleZone()

        End Sub
#End Region

#Region "Event"

        Protected Overrides Function OnGetInfo() As ElementInfo

            Dim info As New ElementInfo(Me)
            info.ToolBoxCaption = My.Resources.text.LocalizableOpen._0336 'Tableau
            info.VersionMajor = 1
            info.VersionMinor = 0
            info.GroupName = "NBGroupStandard"
            info.ToolBoxIco = My.Resources.WETable
            info.ToolBoxDescription = My.Resources.text.LocalizableOpen._0337 '"Ajouter un tableau"

            'Raccourcis  vers les actions sur le tableau
            info.SortPropertyList.Add(New SortProperty("Action:ActAddRow", "row_add_after.png", My.Resources.text.LocalizableOpen._0338)) '"Ajouter une ligne"
            info.SortPropertyList.Add(New SortProperty("Action:ActAddColumn", "column_add_after.png", My.Resources.text.LocalizableOpen._0339)) ' "Ajouter une colonne"
            info.SortPropertyList.Add(New SortProperty("Action:ActDeleteRow", "row_delete.png", My.Resources.text.LocalizableOpen._0340)) ' "Supprimer la ligne sélectionnée"
            info.SortPropertyList.Add(New SortProperty("Action:ActDeleteColumn", "column_delete.png", My.Resources.text.LocalizableOpen._0341)) ' "Supprimer la colonne sélectionnée"
            info.SortPropertyList.Add(New SortProperty("Action:ActInsertRow", "row_add.png", My.Resources.text.LocalizableOpen._0342)) ' "Inserer une ligne après celle sélectionnée"
            info.SortPropertyList.Add(New SortProperty("Action:ActInsertColumn", "column_add.png", My.Resources.text.LocalizableOpen._0343)) ' "Inserer une colonne après celle sélectionnée"
            info.SortPropertyList.Add(New SortProperty("Action:ActInsertCellStylesZone", "row_styles.png", My.Resources.text.LocalizableOpen._0398)) ' "Inserer une zone de styles"

            Return info

        End Function

        ''' <summary>
        ''' configuration de l'élément
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnOpen()

            MyBase.OnOpen(InitStyleZone, False)
        End Sub




        ''' <summary>
        ''' Creation des zones de style avant le render
        ''' </summary>
        ''' <param name="Mode"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageBeforeRender(ByVal Mode As openElement.WebElement.Page.EnuTypeRenderMode)
            MyBase.UpdateConfigStylesZones(ConfigStylesZones, False)
            MyBase.OnPageBeforeRender(Mode)
        End Sub
#End Region

#Region "Gestion des zones de styles"

        ''' <summary>
        ''' Initialisation des zones de style
        ''' </summary>
        ''' <remarks></remarks>
        Private Function InitStyleZone() As List(Of StylesManager.ConfigStylesZone)

            ConfigStylesZones.Clear()
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("TableMain", My.Resources.text.LocalizableOpen._0344, My.Resources.text.LocalizableOpen._0345)) ' "Cadre"  "Cadre du tableau"
            ConfigStylesZones.Add(New StylesManager.ConfigStylesZone("TableCell", My.Resources.text.LocalizableOpen._0346, My.Resources.text.LocalizableOpen._0347)) ' "Cellules"  "Ensemble des cellules du tableau"

            For Row As Integer = 0 To NbRow - 1

                ConfigStylesZones.Add(CreateRowStylesZones(Row))

                For Col As Integer = 0 To NbCol - 1
                    If Row > 0 Then ConfigStylesZones.Add(CreateColStylesZones(Col)) '"Cellule : colonne {0} ligne {1}"  "Style de la cellule"
                    If Me.NumUpdate < 1 Then Call AddCellStyleZone(Row, Col)
                Next

            Next
            Return ConfigStylesZones

        End Function

#Region "Mick ajout"

        Private Function CreateRowStylesZones(ByVal row As Integer) As StylesManager.ConfigStylesZone


            Dim configSZ = New StylesManager.ConfigStylesZone(CreateRowStyleName(row), String.Format(My.Resources.text.LocalizableOpen._0350, row), My.Resources.text.LocalizableOpen._0351)
            With configSZ
                .Level = StylesManager.StylesZone.EnuLevel.Advenced
                .NoSaveInModel = True
            End With

            Return configSZ

        End Function

        Private Function CreateColStylesZones(ByVal Col As Integer) As StylesManager.ConfigStylesZone

            Dim ConfigSZ = New StylesManager.ConfigStylesZone(CreateColumnStyleName(Col), String.Format(My.Resources.text.LocalizableOpen._0352, Col), My.Resources.text.LocalizableOpen._0353)
            With ConfigSZ
                .Level = StylesManager.StylesZone.EnuLevel.Advenced
                .NoSaveInModel = True
            End With

            Return ConfigSZ

        End Function

        Private Function CreateCelStylesZones(ByVal Row As Integer, ByVal Col As Integer) As StylesManager.ConfigStylesZone

            Dim ConfigSZ = New StylesManager.ConfigStylesZone(CreateCellStyleName(Row, Col), String.Format(My.Resources.text.LocalizableOpen._0348, Col, Row), My.Resources.text.LocalizableOpen._0349)
            With ConfigSZ
                .Level = StylesManager.StylesZone.EnuLevel.AdvencedSelectable
                .NoSaveInModel = True
            End With

            Return ConfigSZ

        End Function

#End Region



        ''' <summary>
        ''' Ajout des zones de style d'une ligne
        ''' </summary>
        ''' <param name="row">index de la ligne</param>
        Private Sub AddRowStyleZone(ByVal row As Integer)
            ConfigStylesZones.Add(CreateRowStylesZones(row)) '"Cellule : colonne {0} ligne {1}"  "Style de la cellule"
            If Me.NumUpdate < 1 Then
                For Col As Integer = 0 To NbCol - 1
                    Call AddCellStyleZone(row, Col)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Suppression des zones de style d'une ligne
        ''' </summary>
        ''' <param name="row">index de la ligne</param>
        ''' <remarks></remarks>
        Private Sub DeleteRowStyleZone(ByVal row As Integer)
            Dim zoneIndex As Integer = FindIndexStyleZone(CreateRowStyleName(row))
            If zoneIndex > -1 Then ConfigStylesZones.RemoveAt(zoneIndex)
            If Me.NumUpdate < 1 Then
                For Col As Integer = 0 To NbCol - 1
                    Call DeleteCellStyleZone(row, Col)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Ajout des zones de style d'une colonne
        ''' </summary>
        ''' <param name="col">Index de la colonne</param>
        Private Sub AddColumnStyleZone(ByVal col As Integer)
            ConfigStylesZones.Add(CreateColStylesZones(col))
            If Me.NumUpdate < 1 Then
                For Row As Integer = 0 To NbRow - 1
                    Call AddCellStyleZone(Row, col)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Suppression des zones de style d'une colonne
        ''' </summary>
        ''' <param name="col">Index de la colonne</param>
        Private Sub DeleteColumnStyleZone(ByVal col As Integer)
            Dim zoneIndex As Integer = FindIndexStyleZone(CreateColumnStyleName(col))
            If zoneIndex > -1 Then ConfigStylesZones.RemoveAt(zoneIndex)
            If Me.NumUpdate < 1 Then
                For row As Integer = 0 To NbRow - 1
                    Call DeleteCellStyleZone(row, col)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Ajout des zones de style d'une cellule
        ''' </summary>
        ''' <param name="row"></param>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Private Sub AddCellStyleZone(ByVal row As Integer, ByVal col As Integer)
            Dim configStylesZone As StylesManager.ConfigStylesZone = CreateCelStylesZones(row, col)
            ConfigStylesZones.Add(configStylesZone)
        End Sub

        ''' <summary>
        ''' Suppression des zones de style d'un cellule
        ''' </summary>
        ''' <param name="row"></param>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Private Sub DeleteCellStyleZone(ByVal row As Integer, ByVal col As Integer)
            Dim zoneIndex As Integer = FindIndexStyleZone(CreateCellStyleName(row, col))
            If zoneIndex > -1 Then ConfigStylesZones.RemoveAt(zoneIndex)
        End Sub

        ''' <summary>
        ''' Recherche de l'index d'une zone de style
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function FindIndexStyleZone(ByVal Name As String) As Integer
            Dim index As Integer = -1
            For Each item In ConfigStylesZones
                If item.Name.Equals(Name) Then Exit For
                index += 1
            Next
            Return index
        End Function


#End Region



#Region "Gestion des données"
        ''' <summary>
        ''' Ajout d'une ligne
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AddRow()
            'Table.ChangeNbRow(NbRow, NbRow + 1, NbCol)
            Table.AddRow(NbCol)
            Call AddRowStyleZone(NbRow)
            NbRow += 1
            Me.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Normal).Height.Auto = True
        End Sub

        ''' <summary>
        ''' Ajout d'une colonne
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AddColumn()
            'Table.ChangeNbCol(NbCol, NbCol + 1)
            Table.AddColumn()
            Call AddColumnStyleZone(NbCol)

            NbCol += 1
            Me.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Normal).Width.Auto = True
        End Sub

        ''' <summary>
        ''' Suppression d'une ligne
        ''' </summary>
        ''' <remarks></remarks>
        Private Function DeleteRow(ByVal DelRow As Integer) As Boolean

            'Mise à jour des données
            Table.DeleteRow(DelRow)

            'Mise a jour des zones de styles
            Call DeleteRowStyleZone(NbRow - 1)
            For row = DelRow To NbRow - 1
                Me.StylesSkin.StylesZoneRename(Me.CreateRowStyleName(row + 1), Me.CreateRowStyleName(row), True)
                If Me.NumUpdate < 1 Then
                    For col = 0 To NbCol - 1
                        Me.StylesSkin.StylesZoneRename(Me.CreateCellStyleName(row + 1, col), Me.CreateCellStyleName(row, col), True)
                    Next
                End If
            Next

            NbRow -= 1
            Me.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Normal).Height.Auto = True

            Return True
        End Function

        ''' <summary>
        ''' Suppression d'une colonne
        ''' </summary>
        ''' <remarks></remarks>
        Private Function DeleteColumn(ByVal DelCol As Integer) As Boolean

            'Mise à jour des donnees
            Table.DeleteColumn(DelCol)

            'Mise a jour des zones de styles
            Call DeleteColumnStyleZone(NbCol - 1)
            If Me.NumUpdate < 1 Then
                For row = 0 To NbRow - 1
                    For col = DelCol To NbCol - 1

                        Me.StylesSkin.StylesZoneRename(Me.CreateColumnStyleName(col + 1), Me.CreateColumnStyleName(col), True)
                        Me.StylesSkin.StylesZoneRename(Me.CreateCellStyleName(row, col + 1), Me.CreateCellStyleName(row, col), True)

                    Next
                Next
            Else
                For col = DelCol To NbCol - 1
                    Me.StylesSkin.StylesZoneRename(Me.CreateColumnStyleName(col + 1), Me.CreateColumnStyleName(col), True)
                Next
            End If

            NbCol -= 1 'attention ne pas utiliser la propriete (pour ne pas supprimer une autre ligne)
            Me.StylesSkin.BaseDiv.FindStyles(StylesManager.StylesZone.EnuStyleState.Normal).Width.Auto = True
        End Function

        ''' <summary>
        ''' Insertion d'une ligne
        ''' </summary>
        ''' <remarks></remarks>
        Private Function InsertRow(ByVal InsRow As Integer) As Boolean


            'Mise a jour des zones de styles
            Call AddRowStyleZone(NbRow)
            For row = NbRow To InsRow + 1 Step -1
                Me.StylesSkin.StylesZoneRename(Me.CreateRowStyleName(row), Me.CreateRowStyleName(row + 1), True)
                If Me.NumUpdate < 1 Then
                    For col = 0 To NbCol - 1
                        Me.StylesSkin.StylesZoneRename(Me.CreateCellStyleName(row, col), Me.CreateCellStyleName(row + 1, col), True)
                    Next
                End If
            Next

            Table.InsertRow(InsRow, NbCol)
            NbRow += 1
        End Function

        ''' <summary>
        ''' Insertion d'une colonne
        ''' </summary>
        ''' <remarks></remarks>
        Private Function InsertColumn(ByVal InsCol As Integer) As Boolean
            If Not GetActiveCell() Then Return False
            If _ActiveCol < 0 Then Return False


            'Mise a jour des zones de styles
            Call AddColumnStyleZone(NbCol)
            For row = 0 To NbRow - 1
                For col = NbCol To InsCol + 1 Step -1
                    Me.StylesSkin.StylesZoneRename(Me.CreateColumnStyleName(col), Me.CreateColumnStyleName(col + 1), True)
                    If Me.NumUpdate < 1 Then Me.StylesSkin.StylesZoneRename(Me.CreateCellStyleName(row, col), Me.CreateCellStyleName(row, col + 1), True)
                Next
            Next



            Table.InsertColumn(InsCol)
            NbCol += 1
        End Function

        ''' <summary>
        ''' Changement du nombre de ligne
        ''' </summary>
        ''' <param name="NewNbRow"></param>
        ''' <remarks></remarks>
        Private Sub ChangeNbRow(ByVal NewNbRow As Integer)
            If NbRow = NewNbRow Then Exit Sub

            If NbRow < NewNbRow Then
                'Ajout de ligne
                For row As Integer = NbRow To NewNbRow - 1
                    AddRow()
                Next
            Else
                For row As Integer = NbRow - 1 To NewNbRow Step -1
                    DeleteRow(row)
                Next
            End If
            NbRow = NewNbRow
        End Sub

        ''' <summary>
        ''' Changement du nombre de colonne
        ''' </summary>
        ''' <param name="NewNbCol"></param>
        ''' <remarks></remarks>
        Private Sub ChangeNbColumn(ByVal NewNbCol As Integer)
            If NbCol = NewNbCol Then Exit Sub

            If NbCol < NewNbCol Then
                For col As Integer = NbCol To NewNbCol - 1
                    AddColumn()
                Next
            Else
                For col As Integer = NbCol - 1 To NewNbCol Step -1
                    DeleteColumn(col)
                Next
            End If
            NbCol = NewNbCol
        End Sub
#End Region

#Region "Private"
        ''' <summary>
        ''' Creation du nom des zones de style
        ''' </summary>
        ''' <param name="Row"></param>
        ''' <param name="Col"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateCellStyleName(ByVal Row As Integer, ByVal Col As Integer) As String
            Return String.Concat("Cell-", Row, "-", Col)
        End Function

        ''' <summary>
        ''' Creation de la zone de style d'une ligne (et des cellules de la ligne)
        ''' </summary>
        ''' <param name="row"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateRowStyleName(ByVal row As Integer) As String
            Return String.Concat("Row_", row)
        End Function

        ''' <summary>
        ''' Creation de la zone de style d'une colonne (et des cellules de la colonne)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateColumnStyleName(ByVal col As Integer) As String
            Return String.Concat("Column_", col)
        End Function

        ''' <summary>
        ''' Recuperation du numero de cellule et de ligne active
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetActiveCell() As Boolean
            _ActiveRow = -1
            _ActiveCol = -1
            Dim activeZoneName As String = MyBase.GetCurrentPropertyName
            If Not activeZoneName.StartsWith("Cell(") Then Return False
            activeZoneName = activeZoneName.Substring(5, activeZoneName.Length - 6)
            Dim spl() As String = activeZoneName.Split(",")
            If spl.Length <> 2 Then Return False
            Me._ActiveRow = Convert.ToInt32(spl(0))
            Me._ActiveCol = Convert.ToInt32(spl(1))
            Return True
        End Function

#End Region

#Region "Render"

        ''' <summary>
        ''' Affichage
        ''' </summary>
        ''' <param name="writer"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub Render(ByVal writer As Common.HtmlWriter)


            MyBase.RenderBeginTag(writer)

            writer.WriteBeginTag("table")
            writer.WriteAttribute("class", MyBase.GetStyleZoneClass("TableMain"))
            writer.Write(Web.UI.HtmlTextWriter.TagRightChar)

            If Me.Informer Then
                writer.WriteBeginTag("tr")
                writer.WriteAttribute("style", "border:1px dotted LightGray; background-color:#EEEEEE; font-family :Comic Sans MS ; font-size :10px; color :#666666; height:16px; text-align:center;")
                writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()

                writer.WriteBeginTag("td")
                writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                writer.Write("")
                writer.WriteEndTag("td")

                For col As Integer = 0 To NbCol - 1
                    writer.WriteBeginTag("td")
                    writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                    writer.Write(col)
                    writer.WriteEndTag("td")
                Next
                writer.WriteEndTag("tr")
            End If

            writer.WriteLine()
            writer.Indent += 1
            For row As Integer = 0 To NbRow - 1
                writer.WriteBeginTag("tr")
                writer.WriteAttribute("class", MyBase.GetStyleZoneClass(CreateRowStyleName(row)))
                writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                writer.WriteLine()
                If Me.Informer Then
                    writer.WriteBeginTag("td")
                    writer.WriteAttribute("style", "border:1px dotted LightGray; background-color:#EEEEEE; font-family :Comic Sans MS ; font-size :10px; color :#666666;width:16px;text-align:center;")
                    writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                    writer.Write(row)
                    writer.WriteEndTag("td")
                End If
                For col As Integer = 0 To NbCol - 1
                    writer.WriteBeginTag("td")
                    Dim classList As String() = {CreateCellStyleName(row, col), "TableCell", Me.CreateColumnStyleName(col)}
                    writer.WriteAttribute("class", String.Concat(MyBase.GetStyleZoneClass(classList), " ", "WEEdTableCell"))
                    writer.Write(Web.UI.HtmlTextWriter.TagRightChar)
                    If NotEditable Then
                        writer.WriteHtmlBlock(Me, "Cell(" & row & "," & col & ")")
                    Else
                        writer.WriteHtmlBlockEdit(Me, "Cell(" & row & "," & col & ")", True, , Common.HtmlWriter.BlockType.MaxBox)
                    End If
                    writer.WriteEndTag("td")
                    writer.WriteLine()
                Next

                writer.WriteEndTag("tr")
                writer.Indent -= 1
                writer.WriteLine()
            Next

            writer.WriteEndTag("table")


            MyBase.RenderEndTag(writer)


        End Sub

#End Region




    End Class


    ''' <summary>
    ''' Sturcture de données de WETable - lignes
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WETableData
        <Common.Attributes.ContainsLinks()> _
        Private _Rows As List(Of WETableColumn)

        ''' <summary>
        ''' Lignes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Rows() As List(Of WETableColumn)
            Get
                If _Rows Is Nothing Then _Rows = New List(Of WETableColumn)
                Return _Rows
            End Get
            Set(ByVal value As List(Of WETableColumn))
                _Rows = value
            End Set
        End Property

        ''' <summary>
        ''' Constructeur
        ''' </summary>
        ''' <param name="NbRow">Nombre de ligne</param>
        ''' <param name="NbCol">Nombre de colonne</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal NbRow As Integer, ByVal NbCol As Integer)
            For i As Integer = 0 To NbRow - 1
                Rows.Add(New WETableColumn(NbCol))
            Next
        End Sub

        ''' <summary>
        ''' Ajout d'une ligne
        ''' </summary>
        ''' <param name="NbCol"></param>
        ''' <remarks></remarks>
        Public Sub AddRow(ByVal NbCol As Integer)
            Rows.Add(New WETableColumn(NbCol))
        End Sub

        ''' <summary>
        ''' Ajout d'une colonne
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddColumn()
            For row As Integer = 0 To Rows.Count - 1
                Rows(row).AddColumn()
            Next
        End Sub

        ''' <summary>
        ''' Suppression d'une ligne
        ''' </summary>
        ''' <param name="row"></param>
        ''' <remarks></remarks>
        Public Sub DeleteRow(ByVal row As Integer)
            Rows(row).DisposeColumn()
            Rows.RemoveAt(row)
        End Sub

        ''' <summary>
        ''' Suppression d'une colonne
        ''' </summary>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Public Sub DeleteColumn(ByVal col As Integer)
            For row As Integer = 0 To Rows.Count - 1
                Rows(row).DisposeColumn(col)
            Next
        End Sub

        ''' <summary>
        ''' Insertion d'une ligne
        ''' </summary>
        ''' <param name="IndexRow"></param>
        ''' <param name="NbCol"></param>
        ''' <remarks></remarks>
        Public Sub InsertRow(ByVal IndexRow As Integer, ByVal NbCol As Integer)
            Rows.Insert(IndexRow + 1, New WETableColumn(NbCol))
        End Sub

        ''' <summary>
        ''' Insertion d'une colonne
        ''' </summary>
        ''' <param name="IndexCol"></param>
        ''' <remarks></remarks>
        Public Sub InsertColumn(ByVal IndexCol As Integer)
            For row = 0 To Rows.Count - 1
                Rows(row).InsertColumn(IndexCol + 1)
            Next
        End Sub

        ''' <summary>
        ''' Recuperer la valeur de la cellule
        ''' </summary>
        ''' <param name="Row"></param>
        ''' <param name="Col"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLocalizableHtml(ByVal Row As Integer, ByVal Col As Integer) As LocalizableHtml
            Return Rows(Row).GetLocalizableHtml(Col)
        End Function

        ''' <summary>
        ''' Attribution de la valeur d'une cellule
        ''' </summary>
        ''' <param name="Row"></param>
        ''' <param name="Col"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Sub SetValue(ByVal Row As Integer, ByVal Col As Integer, ByVal Value As LocalizableHtml)
            Rows(Row).SetValue(Col, Value)
        End Sub
    End Class

    ''' <summary>
    ''' Sturcture de données de WETable - colonnes
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WETableColumn
        <Common.Attributes.ContainsLinks()> _
        Private _Columns As List(Of WETableCell)

        ''' <summary>
        ''' Colonnes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Columns() As List(Of WETableCell)
            Get
                If _Columns Is Nothing Then _Columns = New List(Of WETableCell)
                Return _Columns
            End Get
            Set(ByVal value As List(Of WETableCell))
                _Columns = value
            End Set
        End Property

        ''' <summary>
        ''' Constructeur
        ''' </summary>
        ''' <param name="NbCol"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal NbCol As Integer)
            For i As Integer = 0 To NbCol - 1
                Call AddColumn()
            Next
        End Sub

        ''' <summary>
        ''' Ajout d'une colonne vide
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddColumn()
            Columns.Add(New WETableCell)
        End Sub

        ''' <summary>
        ''' Suppression d'une colonne
        ''' </summary>
        ''' <param name="col"></param>
        ''' <remarks></remarks>
        Public Sub DisposeColumn(ByVal col As Integer)
            Columns(col).Dispose()
            Columns.RemoveAt(col)
        End Sub

        ''' <summary>
        ''' Suppression de toutes les colonnes de la ligne
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DisposeColumn()
            For col = 0 To Columns.Count - 1
                Columns(col).Dispose()
            Next
            Me.Columns.Clear()
            Columns = Nothing
        End Sub

        ''' <summary>
        ''' Insertion d'une colonne
        ''' </summary>
        ''' <param name="IndexCol"></param>
        ''' <remarks></remarks>
        Public Sub InsertColumn(ByVal IndexCol As Integer)
            Columns.Insert(IndexCol, New WETableCell)
        End Sub

        ''' <summary>
        ''' Recuperer la valeur de la cellule dans la ligne
        ''' </summary>
        ''' <param name="Col"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLocalizableHtml(ByVal Col As Integer) As LocalizableHtml
            Return Columns(Col).LocalHTML
        End Function

        ''' <summary>
        ''' Attribution de la valeur d'une cellule dans la ligne
        ''' </summary>
        ''' <param name="Col"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Sub SetValue(ByVal Col As Integer, ByVal Value As LocalizableHtml)
            Columns(Col).LocalHTML = Value
        End Sub

    End Class


    ''' <summary>
    ''' Sturcture de données de WETable - Cellule 
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class WETableCell
        Implements IDisposable
        Private _LocalHTML As LocalizableHtml

        Public Property LocalHTML() As LocalizableHtml
            Get
                If _LocalHTML Is Nothing Then _LocalHTML = New LocalizableHtml
                Return _LocalHTML
            End Get
            Set(ByVal value As LocalizableHtml)
                _LocalHTML = value
            End Set
        End Property

        Public Sub New()

        End Sub

#Region "Implement"
        Public Sub Dispose() Implements IDisposable.Dispose
            Me.LocalHTML.Dispose()
            Me.LocalHTML = Nothing
        End Sub
#End Region


    End Class




End Namespace