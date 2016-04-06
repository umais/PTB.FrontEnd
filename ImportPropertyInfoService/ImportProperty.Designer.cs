namespace ImportPropertyInfoService
{
    partial class ImportProperty
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fsExcelWatcher = new System.IO.FileSystemWatcher();
            this.fsExcelUpdateWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fsExcelWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsExcelUpdateWatcher)).BeginInit();
            // 
            // fsExcelWatcher
            // 
            this.fsExcelWatcher.EnableRaisingEvents = true;
            this.fsExcelWatcher.Filter = "*.xlsx";
            this.fsExcelWatcher.Created += new System.IO.FileSystemEventHandler(this.fsExcelWatcher_Created);
            // 
            // fsExcelUpdateWatcher
            // 
            this.fsExcelUpdateWatcher.EnableRaisingEvents = true;
            this.fsExcelUpdateWatcher.Filter = "*.csv";
            this.fsExcelUpdateWatcher.Created += new System.IO.FileSystemEventHandler(this.fsExcelUpdateWatcher_Created);
            // 
            // ImportProperty
            // 
            this.ServiceName = "ImportProperty";
            ((System.ComponentModel.ISupportInitialize)(this.fsExcelWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsExcelUpdateWatcher)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher fsExcelWatcher;
        private System.IO.FileSystemWatcher fsExcelUpdateWatcher;

    }
}
