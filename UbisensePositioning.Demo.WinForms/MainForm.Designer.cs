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
      this.label6 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.btnGetPos = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.btnRemove = new System.Windows.Forms.Button();
      this.lblCurrentPosZ = new System.Windows.Forms.Label();
      this.lblCurrentPosY = new System.Windows.Forms.Label();
      this.lblCurrentPosX = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tboxNewPosZ = new System.Windows.Forms.TextBox();
      this.tboxNewPosY = new System.Windows.Forms.TextBox();
      this.tboxNewPosX = new System.Windows.Forms.TextBox();
      this.btnSetPos = new System.Windows.Forms.Button();
      this.listEntries = new System.Windows.Forms.ListView();
      this.ObjID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ObjName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblSelectedName = new System.Windows.Forms.Label();
      this.lblSelectedObj = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      //
      // label6
      //
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(22, 321);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(10, 9);
      this.label6.TabIndex = 38;
      this.label6.Text = "Z";
      //
      // label10
      //
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(22, 295);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(10, 9);
      this.label10.TabIndex = 37;
      this.label10.Text = "Y";
      //
      // label11
      //
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(22, 269);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(10, 9);
      this.label11.TabIndex = 36;
      this.label11.Text = "X";
      //
      // btnGetPos
      //
      this.btnGetPos.Location = new System.Drawing.Point(41, 340);
      this.btnGetPos.Name = "btnGetPos";
      this.btnGetPos.Size = new System.Drawing.Size(99, 23);
      this.btnGetPos.TabIndex = 23;
      this.btnGetPos.Text = "Get Position";
      this.btnGetPos.UseVisualStyleBackColor = true;
      this.btnGetPos.Click += new System.EventHandler(this.btnGetPos_Click);
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
      // btnRemove
      //
      this.btnRemove.Location = new System.Drawing.Point(322, 340);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(99, 23);
      this.btnRemove.TabIndex = 28;
      this.btnRemove.TabStop = false;
      this.btnRemove.Text = "Remove Position";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      //
      // lblCurrentPosZ
      //
      this.lblCurrentPosZ.AutoSize = true;
      this.lblCurrentPosZ.Location = new System.Drawing.Point(38, 317);
      this.lblCurrentPosZ.Name = "lblCurrentPosZ";
      this.lblCurrentPosZ.Size = new System.Drawing.Size(16, 13);
      this.lblCurrentPosZ.TabIndex = 21;
      this.lblCurrentPosZ.Text = "---";
      //
      // lblCurrentPosY
      //
      this.lblCurrentPosY.AutoSize = true;
      this.lblCurrentPosY.Location = new System.Drawing.Point(38, 291);
      this.lblCurrentPosY.Name = "lblCurrentPosY";
      this.lblCurrentPosY.Size = new System.Drawing.Size(16, 13);
      this.lblCurrentPosY.TabIndex = 22;
      this.lblCurrentPosY.Text = "---";
      //
      // lblCurrentPosX
      //
      this.lblCurrentPosX.AutoSize = true;
      this.lblCurrentPosX.Location = new System.Drawing.Point(38, 265);
      this.lblCurrentPosX.Name = "lblCurrentPosX";
      this.lblCurrentPosX.Size = new System.Drawing.Size(16, 13);
      this.lblCurrentPosX.TabIndex = 19;
      this.lblCurrentPosX.Text = "---";
      //
      // label3
      //
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(171, 321);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(10, 9);
      this.label3.TabIndex = 20;
      this.label3.Text = "Z";
      //
      // label2
      //
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(171, 295);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(10, 9);
      this.label2.TabIndex = 17;
      this.label2.Text = "Y";
      //
      // label1
      //
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(171, 269);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(10, 9);
      this.label1.TabIndex = 18;
      this.label1.Text = "X";
      //
      // tboxNewPosZ
      //
      this.tboxNewPosZ.Location = new System.Drawing.Point(190, 314);
      this.tboxNewPosZ.Name = "tboxNewPosZ";
      this.tboxNewPosZ.Size = new System.Drawing.Size(99, 20);
      this.tboxNewPosZ.TabIndex = 26;
      //
      // tboxNewPosY
      //
      this.tboxNewPosY.Location = new System.Drawing.Point(190, 288);
      this.tboxNewPosY.Name = "tboxNewPosY";
      this.tboxNewPosY.Size = new System.Drawing.Size(99, 20);
      this.tboxNewPosY.TabIndex = 25;
      //
      // tboxNewPosX
      //
      this.tboxNewPosX.Location = new System.Drawing.Point(190, 262);
      this.tboxNewPosX.Name = "tboxNewPosX";
      this.tboxNewPosX.Size = new System.Drawing.Size(99, 20);
      this.tboxNewPosX.TabIndex = 24;
      //
      // btnSetPos
      //
      this.btnSetPos.Location = new System.Drawing.Point(190, 340);
      this.btnSetPos.Name = "btnSetPos";
      this.btnSetPos.Size = new System.Drawing.Size(99, 23);
      this.btnSetPos.TabIndex = 27;
      this.btnSetPos.Text = "Set Position";
      this.btnSetPos.UseVisualStyleBackColor = true;
      this.btnSetPos.Click += new System.EventHandler(this.btnSetPos_Click);
      //
      // listEntries
      //
      this.listEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ObjID,
            this.ObjName});
      this.listEntries.Location = new System.Drawing.Point(15, 25);
      this.listEntries.MultiSelect = false;
      this.listEntries.Name = "listEntries";
      this.listEntries.Size = new System.Drawing.Size(406, 171);
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
      this.groupBox1.Controls.Add(this.lblSelectedName);
      this.groupBox1.Controls.Add(this.lblSelectedObj);
      this.groupBox1.Controls.Add(this.label13);
      this.groupBox1.Controls.Add(this.label14);
      this.groupBox1.Location = new System.Drawing.Point(15, 202);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(406, 54);
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
      // MainForm
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(437, 388);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.listEntries);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.btnGetPos);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.lblCurrentPosZ);
      this.Controls.Add(this.lblCurrentPosY);
      this.Controls.Add(this.lblCurrentPosX);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tboxNewPosZ);
      this.Controls.Add(this.tboxNewPosY);
      this.Controls.Add(this.tboxNewPosX);
      this.Controls.Add(this.btnSetPos);
      this.Name = "MainForm";
      this.Text = "UbisensePositioning Demo";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Button btnGetPos;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Label lblCurrentPosZ;
    private System.Windows.Forms.Label lblCurrentPosY;
    private System.Windows.Forms.Label lblCurrentPosX;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tboxNewPosZ;
    private System.Windows.Forms.TextBox tboxNewPosY;
    private System.Windows.Forms.TextBox tboxNewPosX;
    private System.Windows.Forms.Button btnSetPos;
    private System.Windows.Forms.ListView listEntries;
    private System.Windows.Forms.ColumnHeader ObjID;
    private System.Windows.Forms.ColumnHeader ObjName;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblSelectedName;
    private System.Windows.Forms.Label lblSelectedObj;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
  }
}

