namespace DataBindingWinForms
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.wideWorldImportersDataSet = new DataBindingWinForms.WideWorldImportersDataSet();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordersTableAdapter = new DataBindingWinForms.WideWorldImportersDataSetTableAdapters.OrdersTableAdapter();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salespersonPersonIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickedByPersonIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactPersonIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backorderOrderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expectedDeliveryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerPurchaseOrderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUndersupplyBackorderedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.commentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryInstructionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.internalCommentsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickingCompletedWhenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastEditedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastEditedWhenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wideWorldImportersDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIDDataGridViewTextBoxColumn,
            this.customerIDDataGridViewTextBoxColumn,
            this.salespersonPersonIDDataGridViewTextBoxColumn,
            this.pickedByPersonIDDataGridViewTextBoxColumn,
            this.contactPersonIDDataGridViewTextBoxColumn,
            this.backorderOrderIDDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.expectedDeliveryDateDataGridViewTextBoxColumn,
            this.customerPurchaseOrderNumberDataGridViewTextBoxColumn,
            this.isUndersupplyBackorderedDataGridViewCheckBoxColumn,
            this.commentsDataGridViewTextBoxColumn,
            this.deliveryInstructionsDataGridViewTextBoxColumn,
            this.internalCommentsDataGridViewTextBoxColumn,
            this.pickingCompletedWhenDataGridViewTextBoxColumn,
            this.lastEditedByDataGridViewTextBoxColumn,
            this.lastEditedWhenDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ordersBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // wideWorldImportersDataSet
            // 
            this.wideWorldImportersDataSet.DataSetName = "WideWorldImportersDataSet";
            this.wideWorldImportersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "Orders";
            this.ordersBindingSource.DataSource = this.wideWorldImportersDataSet;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            // 
            // salespersonPersonIDDataGridViewTextBoxColumn
            // 
            this.salespersonPersonIDDataGridViewTextBoxColumn.DataPropertyName = "SalespersonPersonID";
            this.salespersonPersonIDDataGridViewTextBoxColumn.HeaderText = "SalespersonPersonID";
            this.salespersonPersonIDDataGridViewTextBoxColumn.Name = "salespersonPersonIDDataGridViewTextBoxColumn";
            // 
            // pickedByPersonIDDataGridViewTextBoxColumn
            // 
            this.pickedByPersonIDDataGridViewTextBoxColumn.DataPropertyName = "PickedByPersonID";
            this.pickedByPersonIDDataGridViewTextBoxColumn.HeaderText = "PickedByPersonID";
            this.pickedByPersonIDDataGridViewTextBoxColumn.Name = "pickedByPersonIDDataGridViewTextBoxColumn";
            // 
            // contactPersonIDDataGridViewTextBoxColumn
            // 
            this.contactPersonIDDataGridViewTextBoxColumn.DataPropertyName = "ContactPersonID";
            this.contactPersonIDDataGridViewTextBoxColumn.HeaderText = "ContactPersonID";
            this.contactPersonIDDataGridViewTextBoxColumn.Name = "contactPersonIDDataGridViewTextBoxColumn";
            // 
            // backorderOrderIDDataGridViewTextBoxColumn
            // 
            this.backorderOrderIDDataGridViewTextBoxColumn.DataPropertyName = "BackorderOrderID";
            this.backorderOrderIDDataGridViewTextBoxColumn.HeaderText = "BackorderOrderID";
            this.backorderOrderIDDataGridViewTextBoxColumn.Name = "backorderOrderIDDataGridViewTextBoxColumn";
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            // 
            // expectedDeliveryDateDataGridViewTextBoxColumn
            // 
            this.expectedDeliveryDateDataGridViewTextBoxColumn.DataPropertyName = "ExpectedDeliveryDate";
            this.expectedDeliveryDateDataGridViewTextBoxColumn.HeaderText = "ExpectedDeliveryDate";
            this.expectedDeliveryDateDataGridViewTextBoxColumn.Name = "expectedDeliveryDateDataGridViewTextBoxColumn";
            // 
            // customerPurchaseOrderNumberDataGridViewTextBoxColumn
            // 
            this.customerPurchaseOrderNumberDataGridViewTextBoxColumn.DataPropertyName = "CustomerPurchaseOrderNumber";
            this.customerPurchaseOrderNumberDataGridViewTextBoxColumn.HeaderText = "CustomerPurchaseOrderNumber";
            this.customerPurchaseOrderNumberDataGridViewTextBoxColumn.Name = "customerPurchaseOrderNumberDataGridViewTextBoxColumn";
            // 
            // isUndersupplyBackorderedDataGridViewCheckBoxColumn
            // 
            this.isUndersupplyBackorderedDataGridViewCheckBoxColumn.DataPropertyName = "IsUndersupplyBackordered";
            this.isUndersupplyBackorderedDataGridViewCheckBoxColumn.HeaderText = "IsUndersupplyBackordered";
            this.isUndersupplyBackorderedDataGridViewCheckBoxColumn.Name = "isUndersupplyBackorderedDataGridViewCheckBoxColumn";
            // 
            // commentsDataGridViewTextBoxColumn
            // 
            this.commentsDataGridViewTextBoxColumn.DataPropertyName = "Comments";
            this.commentsDataGridViewTextBoxColumn.HeaderText = "Comments";
            this.commentsDataGridViewTextBoxColumn.Name = "commentsDataGridViewTextBoxColumn";
            // 
            // deliveryInstructionsDataGridViewTextBoxColumn
            // 
            this.deliveryInstructionsDataGridViewTextBoxColumn.DataPropertyName = "DeliveryInstructions";
            this.deliveryInstructionsDataGridViewTextBoxColumn.HeaderText = "DeliveryInstructions";
            this.deliveryInstructionsDataGridViewTextBoxColumn.Name = "deliveryInstructionsDataGridViewTextBoxColumn";
            // 
            // internalCommentsDataGridViewTextBoxColumn
            // 
            this.internalCommentsDataGridViewTextBoxColumn.DataPropertyName = "InternalComments";
            this.internalCommentsDataGridViewTextBoxColumn.HeaderText = "InternalComments";
            this.internalCommentsDataGridViewTextBoxColumn.Name = "internalCommentsDataGridViewTextBoxColumn";
            // 
            // pickingCompletedWhenDataGridViewTextBoxColumn
            // 
            this.pickingCompletedWhenDataGridViewTextBoxColumn.DataPropertyName = "PickingCompletedWhen";
            this.pickingCompletedWhenDataGridViewTextBoxColumn.HeaderText = "PickingCompletedWhen";
            this.pickingCompletedWhenDataGridViewTextBoxColumn.Name = "pickingCompletedWhenDataGridViewTextBoxColumn";
            // 
            // lastEditedByDataGridViewTextBoxColumn
            // 
            this.lastEditedByDataGridViewTextBoxColumn.DataPropertyName = "LastEditedBy";
            this.lastEditedByDataGridViewTextBoxColumn.HeaderText = "LastEditedBy";
            this.lastEditedByDataGridViewTextBoxColumn.Name = "lastEditedByDataGridViewTextBoxColumn";
            // 
            // lastEditedWhenDataGridViewTextBoxColumn
            // 
            this.lastEditedWhenDataGridViewTextBoxColumn.DataPropertyName = "LastEditedWhen";
            this.lastEditedWhenDataGridViewTextBoxColumn.HeaderText = "LastEditedWhen";
            this.lastEditedWhenDataGridViewTextBoxColumn.Name = "lastEditedWhenDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wideWorldImportersDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private WideWorldImportersDataSet wideWorldImportersDataSet;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private WideWorldImportersDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salespersonPersonIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickedByPersonIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactPersonIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backorderOrderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expectedDeliveryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerPurchaseOrderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUndersupplyBackorderedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryInstructionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn internalCommentsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickingCompletedWhenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastEditedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastEditedWhenDataGridViewTextBoxColumn;
    }
}

