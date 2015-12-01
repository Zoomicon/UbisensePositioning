//Project: UbisensePositioning (http://UbisensePositioning.codeplex.com)
//Filename: MainForm.cs
//Version: 20151110

namespace Ubisense.Positioning
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label9 = new System.Windows.Forms.Label();
      this.listEntries = new System.Windows.Forms.ListView();
      this.ObjID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ObjName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblSelectedName = new System.Windows.Forms.Label();
      this.lblSelectedObj = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.groupBoxPosition = new System.Windows.Forms.GroupBox();
      this.btnGetPos = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtPositionZ = new System.Windows.Forms.TextBox();
      this.txtPositionY = new System.Windows.Forms.TextBox();
      this.txtPositionX = new System.Windows.Forms.TextBox();
      this.btnSetPos = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBoxPosition.SuspendLayout();
      this.SuspendLayout();
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(12, 9);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(89, 13);
      this.label9.TabIndex = 35;
      this.label9.Text = "Available Objects";
      // 
      // listEntries
      // 
      this.listEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ObjID,
            this.ObjName});
      this.listEntries.Location = new System.Drawing.Point(15, 25);
      this.listEntries.MultiSelect = false;
      this.listEntries.Name = "listEntries";
      this.listEntries.Size = new System.Drawing.Size(490, 101);
      this.listEntries.TabIndex = 39;
      this.listEntries.TabStop = false;
      this.listEntries.UseCompatibleStateImageBehavior = false;
      this.listEntries.View = System.Windows.Forms.View.Details;
      this.listEntries.SelectedIndexChanged += new System.EventHandler(this.listEntries_SelectedIndexChanged);
      // 
      // ObjID
      // 
      this.ObjID.Text = "Object ID";
      this.ObjID.Width = 224;
      // 
      // ObjName
      // 
      this.ObjName.Text = "Name";
      this.ObjName.Width = 138;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.lblSelectedName);
      this.groupBox1.Controls.Add(this.lblSelectedObj);
      this.groupBox1.Controls.Add(this.label13);
      this.groupBox1.Controls.Add(this.label14);
      this.groupBox1.Location = new System.Drawing.Point(15, 132);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(490, 48);
      this.groupBox1.TabIndex = 40;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Selected Entry";
      // 
      // lblSelectedName
      // 
      this.lblSelectedName.AutoSize = true;
      this.lblSelectedName.Location = new System.Drawing.Point(53, 29);
      this.lblSelectedName.Name = "lblSelectedName";
      this.lblSelectedName.Size = new System.Drawing.Size(16, 13);
      this.lblSelectedName.TabIndex = 23;
      this.lblSelectedName.Text = "---";
      // 
      // lblSelectedObj
      // 
      this.lblSelectedObj.AutoSize = true;
      this.lblSelectedObj.Location = new System.Drawing.Point(53, 16);
      this.lblSelectedObj.Name = "lblSelectedObj";
      this.lblSelectedObj.Size = new System.Drawing.Size(16, 13);
      this.lblSelectedObj.TabIndex = 22;
      this.lblSelectedObj.Text = "---";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(6, 16);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(41, 13);
      this.label13.TabIndex = 20;
      this.label13.Text = "Object:";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(6, 29);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(38, 13);
      this.label14.TabIndex = 21;
      this.label14.Text = "Name:";
      // 
      // groupBoxPosition
      // 
      this.groupBoxPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBoxPosition.Controls.Add(this.btnGetPos);
      this.groupBoxPosition.Controls.Add(this.btnRemove);
      this.groupBoxPosition.Controls.Add(this.label3);
      this.groupBoxPosition.Controls.Add(this.label2);
      this.groupBoxPosition.Controls.Add(this.label1);
      this.groupBoxPosition.Controls.Add(this.txtPositionZ);
      this.groupBoxPosition.Controls.Add(this.txtPositionY);
      this.groupBoxPosition.Controls.Add(this.txtPositionX);
      this.groupBoxPosition.Controls.Add(this.btnSetPos);
      this.groupBoxPosition.Location = new System.Drawing.Point(15, 186);
      this.groupBoxPosition.Name = "groupBoxPosition";
      this.groupBoxPosition.Size = new System.Drawing.Size(490, 47);
      this.groupBoxPosition.TabIndex = 42;
      this.groupBoxPosition.TabStop = false;
      this.groupBoxPosition.Text = "Position";
      // 
      // btnGetPos
      // 
      this.btnGetPos.Location = new System.Drawing.Point(328, 17);
      this.btnGetPos.Name = "btnGetPos";
      this.btnGetPos.Size = new System.Drawing.Size(36, 23);
      this.btnGetPos.TabIndex = 32;
      this.btnGetPos.Text = "Get";
      this.btnGetPos.UseVisualStyleBackColor = true;
      this.btnGetPos.Click += new System.EventHandler(this.btnGetPos_Click);
      // 
      // btnRemove
      // 
      this.btnRemove.Location = new System.Drawing.Point(407, 17);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(73, 23);
      this.btnRemove.TabIndex = 37;
      this.btnRemove.TabStop = false;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(214, 22);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(14, 13);
      this.label3.TabIndex = 31;
      this.label3.Text = "Z";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(109, 22);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(14, 13);
      this.label2.TabIndex = 29;
      this.label2.Text = "Y";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(6, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(14, 13);
      this.label1.TabIndex = 30;
      this.label1.Text = "X";
      // 
      // txtPositionZ
      // 
      this.txtPositionZ.Location = new System.Drawing.Point(234, 19);
      this.txtPositionZ.Name = "txtPositionZ";
      this.txtPositionZ.Size = new System.Drawing.Size(77, 20);
      this.txtPositionZ.TabIndex = 35;
      // 
      // txtPositionY
      // 
      this.txtPositionY.Location = new System.Drawing.Point(129, 19);
      this.txtPositionY.Name = "txtPositionY";
      this.txtPositionY.Size = new System.Drawing.Size(77, 20);
      this.txtPositionY.TabIndex = 34;
      // 
      // txtPositionX
      // 
      this.txtPositionX.Location = new System.Drawing.Point(26, 19);
      this.txtPositionX.Name = "txtPositionX";
      this.txtPositionX.Size = new System.Drawing.Size(77, 20);
      this.txtPositionX.TabIndex = 33;
      // 
      // btnSetPos
      // 
      this.btnSetPos.Location = new System.Drawing.Point(370, 17);
      this.btnSetPos.Name = "btnSetPos";
      this.btnSetPos.Size = new System.Drawing.Size(31, 23);
      this.btnSetPos.TabIndex = 36;
      this.btnSetPos.Text = "Set";
      this.btnSetPos.UseVisualStyleBackColor = true;
      this.btnSetPos.Click += new System.EventHandler(this.btnSetPos_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(517, 241);
      this.Controls.Add(this.groupBoxPosition);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.listEntries);
      this.Controls.Add(this.label9);
      this.Name = "MainForm";
      this.Text = "UbisensePositioning Demo";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBoxPosition.ResumeLayout(false);
      this.groupBoxPosition.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ListView listEntries;
    private System.Windows.Forms.ColumnHeader ObjID;
    private System.Windows.Forms.ColumnHeader ObjName;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblSelectedName;
    private System.Windows.Forms.Label lblSelectedObj;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.GroupBox groupBoxPosition;
    private System.Windows.Forms.Button btnSetPos;
    private System.Windows.Forms.TextBox txtPositionX;
    private System.Windows.Forms.TextBox txtPositionY;
    private System.Windows.Forms.TextBox txtPositionZ;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnGetPos;
  }
}

