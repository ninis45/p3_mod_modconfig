﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrPvt
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrPvt))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TChart1 = New Steema.TeeChart.TChart()
        Me.Axis1 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis2 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis3 = New Steema.TeeChart.Axis(Me.components)
        Me.Axis4 = New Steema.TeeChart.Axis(Me.components)
        Me.Line1 = New Steema.TeeChart.Styles.Line()
        Me.Line2 = New Steema.TeeChart.Styles.Line()
        Me.Line3 = New Steema.TeeChart.Styles.Line()
        Me.Line4 = New Steema.TeeChart.Styles.Line()
        Me.ChartController1 = New Steema.TeeChart.ChartController()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TChart1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ChartController1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(650, 450)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TChart1
        '
        '
        '
        '
        Me.TChart1.Aspect.ColorPaletteIndex = 20
        Me.TChart1.Aspect.View3D = False
        '
        '
        '
        Me.TChart1.Axes.Automatic = True
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Bottom.Grid.DrawEvery = 2
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TChart1.Axes.Bottom.Labels.Font.Size = 9
        Me.TChart1.Axes.Bottom.Labels.Font.SizeFloat = 9.0!
        '
        '
        '
        Me.TChart1.Axes.Bottom.Title.Caption = "Presión(kg/cm2)"
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Bottom.Title.Lines = New String() {"Presión(kg/cm2)"}
        Me.TChart1.Axes.Custom.Add(Me.Axis1)
        Me.TChart1.Axes.Custom.Add(Me.Axis2)
        Me.TChart1.Axes.Custom.Add(Me.Axis3)
        Me.TChart1.Axes.Custom.Add(Me.Axis4)
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Left.Grid.DrawEvery = 2
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.Gray
        Me.TChart1.Axes.Left.Labels.Font.Size = 9
        Me.TChart1.Axes.Left.Labels.Font.SizeFloat = 9.0!
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Left.Title.Font.Size = 11
        Me.TChart1.Axes.Left.Title.Font.SizeFloat = 11.0!
        Me.TChart1.Axes.Left.Visible = False
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Right.Labels.Font.Size = 9
        Me.TChart1.Axes.Right.Labels.Font.SizeFloat = 9.0!
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Axes.Top.Labels.Font.Size = 9
        Me.TChart1.Axes.Top.Labels.Font.SizeFloat = 9.0!
        Me.TChart1.CurrentTheme = Steema.TeeChart.ThemeType.Report
        Me.TChart1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TChart1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Header.Font.Brush.Color = System.Drawing.Color.Gray
        Me.TChart1.Header.Font.Size = 12
        Me.TChart1.Header.Font.SizeFloat = 12.0!
        Me.TChart1.Header.Visible = False
        '
        '
        '
        Me.TChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom
        Me.TChart1.Legend.CheckBoxes = True
        '
        '
        '
        '
        '
        '
        Me.TChart1.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TChart1.Legend.Font.Size = 6
        Me.TChart1.Legend.Font.SizeFloat = 6.0!
        '
        '
        '
        Me.TChart1.Legend.Shadow.Visible = False
        Me.TChart1.Location = New System.Drawing.Point(3, 33)
        Me.TChart1.Name = "TChart1"
        '
        '
        '
        '
        '
        '
        Me.TChart1.Panel.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.TChart1.Panel.Brush.Gradient.Visible = False
        Me.TChart1.Panel.MarginLeft = 16.0R
        Me.TChart1.Panel.MarginRight = 16.0R
        Me.TChart1.Series.Add(Me.Line1)
        Me.TChart1.Series.Add(Me.Line2)
        Me.TChart1.Series.Add(Me.Line3)
        Me.TChart1.Series.Add(Me.Line4)
        Me.TChart1.Size = New System.Drawing.Size(644, 414)
        Me.TChart1.TabIndex = 4
        '
        '
        '
        '
        '
        '
        '
        '
        '
        Me.TChart1.Walls.Back.Brush.Visible = False
        Me.TChart1.Walls.Back.Visible = False
        '
        'Axis1
        '
        '
        '
        '
        Me.Axis1.Grid.Visible = False
        Me.Axis1.Horizontal = False
        '
        '
        '
        Me.Axis1.Labels.CustomSize = 29
        Me.Axis1.Labels.ValueFormat = "0.0"
        Me.Axis1.OtherSide = False
        '
        '
        '
        Me.Axis1.Title.Angle = 90
        Me.Axis1.Title.Caption = "Presión de saturación(kg/cm2)"
        Me.Axis1.Title.Lines = New String() {"Presión de saturación(kg/cm2)"}
        '
        'Axis2
        '
        '
        '
        '
        Me.Axis2.Grid.Visible = False
        Me.Axis2.Horizontal = False
        Me.Axis2.OtherSide = False
        Me.Axis2.RelativePosition = -12.0R
        '
        '
        '
        Me.Axis2.Title.Angle = 90
        Me.Axis2.Title.Caption = "Relación Gas Aceite(m3/m3)"
        Me.Axis2.Title.Lines = New String() {"Relación Gas Aceite(m3/m3)"}
        '
        'Axis3
        '
        '
        '
        '
        Me.Axis3.Grid.Visible = False
        Me.Axis3.Horizontal = False
        '
        '
        '
        Me.Axis3.Labels.CustomSize = 20
        Me.Axis3.OtherSide = True
        '
        '
        '
        Me.Axis3.Title.Angle = 90
        Me.Axis3.Title.Caption = "Factor de Volumen del Aceite (adim)"
        Me.Axis3.Title.Lines = New String() {"Factor de Volumen del Aceite (adim)"}
        Me.Axis3.ZPosition = 0R
        '
        'Axis4
        '
        Me.Axis4.Horizontal = False
        Me.Axis4.OtherSide = True
        Me.Axis4.RelativePosition = -12.0R
        '
        '
        '
        Me.Axis4.Title.Angle = 90
        Me.Axis4.Title.Caption = "Viscosidad del Aceite(cp)"
        Me.Axis4.Title.Lines = New String() {"Viscosidad del Aceite(cp)"}
        Me.Axis4.ZPosition = 0R
        '
        'Line1
        '
        '
        '
        '
        Me.Line1.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.Line1.Color = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.Line1.ColorEach = False
        Me.Line1.CustomVertAxis = Me.Axis1
        '
        '
        '
        Me.Line1.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line1.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line1.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line1.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line1.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line1.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line1.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(193, Byte), Integer))
        '
        '
        '
        Me.Line1.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line1.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line1.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos"), System.Drawing.PointF)
        Me.Line1.Marks.TailParams.Margin = 0!
        Me.Line1.Marks.TailParams.PointerHeight = 5.0R
        Me.Line1.Marks.TailParams.PointerWidth = 8.0R
        Me.Line1.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line1.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Line1.Pointer.SizeDouble = 0R
        Me.Line1.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line1.Title = "Presión de saturación(kg/cm2)"
        Me.Line1.UseExtendedNumRange = False
        Me.Line1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Line1.XValues.DataMember = "X"
        Me.Line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        '
        '
        Me.Line1.YValues.DataMember = "Y"
        '
        'Line2
        '
        '
        '
        '
        Me.Line2.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Line2.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Line2.ColorEach = False
        Me.Line2.CustomVertAxis = Me.Axis2
        '
        '
        '
        Me.Line2.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(62, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line2.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line2.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line2.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line2.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line2.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line2.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        '
        '
        Me.Line2.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line2.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line2.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos1"), System.Drawing.PointF)
        Me.Line2.Marks.TailParams.Margin = 0!
        Me.Line2.Marks.TailParams.PointerHeight = 5.0R
        Me.Line2.Marks.TailParams.PointerWidth = 8.0R
        Me.Line2.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line2.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Line2.Pointer.SizeDouble = 0R
        Me.Line2.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line2.Title = "Relación Gas Aceite(m3/m3)"
        Me.Line2.UseExtendedNumRange = False
        Me.Line2.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        'Line3
        '
        '
        '
        '
        Me.Line3.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Line3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Line3.ColorEach = False
        Me.Line3.CustomVertAxis = Me.Axis3
        '
        '
        '
        Me.Line3.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(43, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line3.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line3.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line3.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line3.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line3.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line3.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        '
        '
        Me.Line3.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line3.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line3.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos2"), System.Drawing.PointF)
        Me.Line3.Marks.TailParams.Margin = 0!
        Me.Line3.Marks.TailParams.PointerHeight = 5.0R
        Me.Line3.Marks.TailParams.PointerWidth = 8.0R
        Me.Line3.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line3.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Line3.Pointer.SizeDouble = 0R
        Me.Line3.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line3.Title = "Factor de Volumen del Aceite (adim)"
        Me.Line3.UseExtendedNumRange = False
        Me.Line3.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Line3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        'Line4
        '
        '
        '
        '
        Me.Line4.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Line4.Color = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Line4.ColorEach = False
        Me.Line4.CustomVertAxis = Me.Axis4
        '
        '
        '
        Me.Line4.LinePen.Color = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(121, Byte), Integer), CType(CType(131, Byte), Integer))
        '
        '
        '
        '
        '
        '
        Me.Line4.Marks.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.Line4.Marks.Brush.Gradient.EndColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Line4.Marks.Brush.Gradient.MiddleColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line4.Marks.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Line4.Marks.Brush.Gradient.UseMiddle = True
        '
        '
        '
        '
        '
        '
        Me.Line4.Marks.Font.Brush.Color = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        '
        '
        '
        Me.Line4.Marks.Pen.Color = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(197, Byte), Integer))
        '
        '
        '
        Me.Line4.Marks.Shadow.Visible = False
        '
        '
        '
        Me.Line4.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.[Auto]
        Me.Line4.Marks.TailParams.CustomPointPos = CType(resources.GetObject("resource.CustomPointPos3"), System.Drawing.PointF)
        Me.Line4.Marks.TailParams.Margin = 0!
        Me.Line4.Marks.TailParams.PointerHeight = 5.0R
        Me.Line4.Marks.TailParams.PointerWidth = 8.0R
        Me.Line4.Marks.TailStyle = Steema.TeeChart.Styles.MarksTail.WithPointer
        Me.Line4.OriginalCursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.Line4.Pointer.SizeDouble = 0R
        Me.Line4.Pointer.SizeUnits = Steema.TeeChart.Styles.PointerSizeUnits.Pixels
        Me.Line4.Title = "Viscosidad del Aceite(cp)"
        Me.Line4.UseExtendedNumRange = False
        Me.Line4.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Custom
        '
        '
        '
        Me.Line4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending
        '
        'ChartController1
        '
        Me.ChartController1.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16
        Me.ChartController1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartController1.LabelValues = True
        Me.ChartController1.Location = New System.Drawing.Point(0, 0)
        Me.ChartController1.Name = "ChartController1"
        Me.ChartController1.Size = New System.Drawing.Size(650, 30)
        Me.ChartController1.TabIndex = 3
        Me.ChartController1.Text = "ChartController1"
        '
        'usrPvt
        '
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "usrPvt"
        Me.Size = New System.Drawing.Size(650, 450)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As Forms.TableLayoutPanel
    Friend WithEvents ChartController1 As Steema.TeeChart.ChartController
    Friend WithEvents TChart1 As Steema.TeeChart.TChart
    Friend WithEvents Line1 As Steema.TeeChart.Styles.Line
    Friend WithEvents Line2 As Steema.TeeChart.Styles.Line
    Friend WithEvents Line3 As Steema.TeeChart.Styles.Line
    Friend WithEvents Line4 As Steema.TeeChart.Styles.Line
    Friend WithEvents Axis1 As Steema.TeeChart.Axis
    Friend WithEvents Axis2 As Steema.TeeChart.Axis
    Friend WithEvents Axis3 As Steema.TeeChart.Axis
    Friend WithEvents Axis4 As Steema.TeeChart.Axis
End Class
