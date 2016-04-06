using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ImportPropertyInfoService
{
    public partial class ImportProperty : ServiceBase
    {
        public ImportProperty()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            fsExcelWatcher.Path = ConfigurationManager.AppSettings["WatchPath"];
            fsExcelUpdateWatcher.Path = ConfigurationManager.AppSettings["WatchPath"];
        }

        protected override void OnStop()
        {
        }

        private void fsExcelWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(15000);
                DateTime starttime = DateTime.Now;
                
                int insertedCount = 0;

                DataTable dt = GetDataTableFromExcel(e.FullPath, true);
                propDBEntities entity = new propDBEntities();
                foreach (DataRow item in dt.Rows)
                {
                    Property_TBL proptbl = new Property_TBL();
                    try
                    {
                        #region Set the Fields from Excel
                        
                        proptbl.apt = GetValue(dt, item, "apt");
                        proptbl.attic = GetValue(dt, item, "attic");
                        proptbl.av_land = GetValue(dt, item, "av_land");
                        proptbl.av_total = GetValue(dt, item, "av_total");
                        proptbl.basement = GetValue(dt, item, "basement");
                        proptbl.bc_amt = GetValue(dt, item, "bc_amt");
                        proptbl.block = GetValue(dt, item, "block");
                        proptbl.bsmt_fin = GetValue(dt, item, "bsmt_fin");
                        proptbl.built = GetValue(dt, item, "built");
                        proptbl.cav_land = GetValue(dt, item, "cav_land");
                        proptbl.cav_total = GetValue(dt, item, "cav_total");
                        proptbl.city = GetValue(dt, item, "city");
                        proptbl.class_suf = GetValue(dt, item, "class_suf");
                        proptbl.Client1 = GetValue(dt, item, "Client1");
                        proptbl.Client2 = GetValue(dt, item, "Client2");
                        proptbl.Client3 = GetValue(dt, item, "Client3");
                        proptbl.Client4 = GetValue(dt, item, "Client4");
                        proptbl.Client5 = GetValue(dt, item, "Client5");
                        proptbl.Client6 = GetValue(dt, item, "Client6");
                        proptbl.Client7 = GetValue(dt, item, "Client7");
                        proptbl.Client8 = GetValue(dt, item, "Client8");
                        proptbl.Client9 = GetValue(dt, item, "Client9");
                        proptbl.Client10 = GetValue(dt, item, "Client10");
                        proptbl.Client11 = GetValue(dt, item, "Client11");
                        proptbl.Client12 = GetValue(dt, item, "Client12");
                        proptbl.Client13 = GetValue(dt, item, "Client13");
                        proptbl.Client14 = GetValue(dt, item, "Client14");
                        proptbl.Client15 = GetValue(dt, item, "Client15");
                        proptbl.code = GetValue(dt, item, "code");
                        proptbl.condolvl = GetValue(dt, item, "condolvl");
                        proptbl.dir = GetValue(dt, item, "dir");
                        proptbl.dista = GetValue(dt, item, "dista");
                        proptbl.district = GetValue(dt, item, "district");
                        proptbl.east = GetValue(dt, item, "east");
                        proptbl.ed_amt = GetValue(dt, item, "ed_amt");
                        proptbl.ext_wall = GetValue(dt, item, "ext_wall");
                        proptbl.fireplace = GetValue(dt, item, "fireplace");
                        proptbl.fld_dt = GetValue(dt, item, "fld_dt");
                        proptbl.fld_pnl = GetValue(dt, item, "fld_pnl");
                        proptbl.fld_zn = GetValue(dt, item, "fld_zn");
                        proptbl.foundation = GetValue(dt, item, "foundation");
                        proptbl.fron = GetValue(dt, item, "fron");
                        proptbl.fuel_type = GetValue(dt, item, "fuel_type");
                        proptbl.full_baths = GetValue(dt, item, "full_baths");
                        proptbl.garage = GetValue(dt, item, "garage");
                        proptbl.half_baths = GetValue(dt, item, "half_baths");
                        proptbl.heat_type = GetValue(dt, item, "heat_type");
                        proptbl.highlight = GetValue(dt, item, "highlight");
                        proptbl.house_numb = GetValue(dt, item, "house_numb");
                        proptbl.ht_enc = GetValue(dt, item, "ht_enc");
                        //proptbl.Id = GetValue(dt, item, "Client15");
                        proptbl.irreg_desc = GetValue(dt, item, "irreg_desc");

                        proptbl.irregular = GetValue(dt, item, "irregular");
                        proptbl.livunit = GetValue(dt, item, "livunit");
                        proptbl.loc = GetValue(dt, item, "loc");
                        proptbl.lot = GetValue(dt, item, "lot");
                        proptbl.lot_acres = GetValue(dt, item, "lot_acres");
                        proptbl.lot_group = GetValue(dt, item, "lot_group");
                        proptbl.lot_size = GetValue(dt, item, "log_size");
                        proptbl.lot1 = GetValue(dt, item, "lot1");
                        proptbl.lspace = GetValue(dt, item, "lspace");
                        proptbl.lsqft = GetValue(dt, item, "lsqft");
                        proptbl.mailing_a1 = GetValue(dt, item, "mailing_a1");
                        proptbl.mailing_ad = GetValue(dt, item, "mailing_ad");
                        proptbl.mgfa = GetValue(dt, item, "mgfa");
                        proptbl.new_dist = GetValue(dt, item, "new_dist");
                        proptbl.north = GetValue(dt, item, "north");
                        proptbl.old_name = GetValue(dt, item, "old_name");
                        proptbl.owner_name = GetValue(dt, item, "owner_name");
                        proptbl.prop_class = GetValue(dt, item, "prop_class");
                        proptbl.rate_t = GetValue(dt, item, "rate_t");
                        proptbl.ratio1 = GetValue(dt, item, "ratio1");
                        proptbl.ratio2 = GetValue(dt, item, "ratio2");
                        proptbl.ratio3 = GetValue(dt, item, "ratio3");
                        proptbl.rec_no= GetValue(dt, item, "rec_no");
                        proptbl.recno = GetValue(dt, item, "recno");
                        proptbl.res_number = GetValue(dt, item, "res_number");
                        proptbl.res_street = GetValue(dt, item, "res_street");
                        proptbl.rooms_bath = GetValue(dt, item, "rooms_bath");
                        if (!proptbl.rooms_bath.Equals(string.Empty))
                        {
                            string laststr = proptbl.rooms_bath.Substring(proptbl.rooms_bath.LastIndexOf('/') + 1);
                            int lstr = 0;
                            if (int.TryParse(laststr, out lstr))
                            {
                                lstr = lstr % 2000;
                                proptbl.rooms_bath = proptbl.rooms_bath.Substring(0, proptbl.rooms_bath.LastIndexOf('/') + 1) + lstr.ToString();
                            }
                        }
                        proptbl.section = GetValue(dt, item, "section");
                        proptbl.src = GetValue(dt, item, "src");
                        proptbl.st_name= GetValue(dt, item, "st_name");
                        proptbl.st_swis_co= GetValue(dt, item, "st_swis_co");
                        proptbl.state = GetValue(dt, item, "state");
                        proptbl.str_ind = GetValue(dt, item, "str_ind");
                        proptbl.street = GetValue(dt, item, "street");
                        proptbl.style = GetValue(dt, item, "style");
                        proptbl.tax_class = GetValue(dt, item, "tax_class");
                        proptbl.topo = GetValue(dt, item, "topo");
                        proptbl.town_code = GetValue(dt, item, "town_code");
                        proptbl.township = GetValue(dt, item, "township");
                        proptbl.traffic = GetValue(dt, item, "traffic");
                        proptbl.tsplit= GetValue(dt, item, "tsplit");
                        proptbl.unit = GetValue(dt, item, "unit");
                        proptbl.util = GetValue(dt, item, "util");
                        proptbl.village = GetValue(dt, item, "village");
                        proptbl.wat_desc= GetValue(dt, item, "wat_desc");
                        proptbl.waterfront = GetValue(dt, item, "waterfront");
                        proptbl.zip_code = GetValue(dt, item, "zip_code");
                        proptbl.zip_code1 = GetValue(dt, item, "zip_code1");
                        #endregion
                        entity.Property_TBL.Add(proptbl);
                        insertedCount++;
                    }
                    catch (Exception ex)
                    {
                        string[] errlog = { DateTime.Now + " File Name:" + e.FullPath + " Exception:" + ex.Message + " Stack Trace:" + ex.StackTrace };
                        File.AppendAllLines(ConfigurationManager.AppSettings["ErrorLogFile"], errlog);
                    }                    
                }
                entity.SaveChanges();
                if (!File.Exists(ConfigurationManager.AppSettings["OutputPath"] + e.Name))
                {
                    System.IO.File.Move(e.FullPath, ConfigurationManager.AppSettings["OutputPath"] + e.Name);
                }
                else
                {
                    File.Delete(ConfigurationManager.AppSettings["OutputPath"] + e.Name);
                    System.IO.File.Move(e.FullPath, ConfigurationManager.AppSettings["OutputPath"] + e.Name);
                }
                AddToCSV(e.Name + "," + insertedCount.ToString() + ",0," + starttime.ToString("yyyy-MM-ddTHH':'mm':'sszzz") + "," + DateTime.Now.ToString("yyyy-MM-ddTHH':'mm':'sszzz"));
            }
            catch (Exception ex)
            {
                string[] errlog = { DateTime.Now + " File Name:" + e.FullPath + " Exception:" + ex.Message + " Stack Trace:" + ex.StackTrace };
                File.AppendAllLines(ConfigurationManager.AppSettings["ErrorLogFile"], errlog);
            }
        }

        public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return tbl;
            }
        }

        public static string GetValue(DataTable dt, DataRow dr, string columnName)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName.Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return Convert.ToString(dr[columnName]);
            }
            return string.Empty;
        }

        private void fsExcelUpdateWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(15000);
                DateTime starttime = DateTime.Now;
                int insertedCount = 0;
                int updatedCount = 0;
                
                DataTable dt = GetDateTableFromCSV(e.FullPath);
                propDBEntities entity = new propDBEntities();
                foreach (DataRow item in dt.Rows)
                {
                    
                    try
                    {
                        string lot,sec, block;
                        lot = GetValue(dt, item, "lot");
                        sec = GetValue(dt, item, "sec");
                        block = GetValue(dt, item, "block");
                        Property_TBL proptbl = entity.Property_TBL.Where(i => i.lot == lot && i.section == sec && i.block == block).FirstOrDefault();
                        bool isnewEntry = false;
                        if (proptbl == null)
                        {
                            proptbl = new Property_TBL();
                            isnewEntry = true;
                            insertedCount++;
                        }
                        else
                        {
                            updatedCount++;
                        }
                        #region Set the Fields from Excel

                        //proptbl.apt = GetValue(dt, item, "apt");
                        //proptbl.attic = GetValue(dt, item, "attic");
                        //proptbl.av_land = GetValue(dt, item, "av_land");
                        proptbl.av_total = GetValue(dt, item, "av_total");
                        //proptbl.basement = GetValue(dt, item, "basement");
                        //proptbl.bc_amt = GetValue(dt, item, "bc_amt");
                        proptbl.block = GetValue(dt, item, "block");
                        //proptbl.bsmt_fin = GetValue(dt, item, "bsmt_fin");
                        proptbl.built = GetValue(dt, item, "built");
                        //proptbl.cav_land = GetValue(dt, item, "cav_land");
                        //proptbl.cav_total = GetValue(dt, item, "cav_total");
                        //proptbl.city = GetValue(dt, item, "city");
                        //proptbl.class_suf = GetValue(dt, item, "class_suf");
                        proptbl.Client1 = GetValue(dt, item, "Client1");
                        proptbl.Client2 = GetValue(dt, item, "Client2");
                        proptbl.Client3 = GetValue(dt, item, "Client3");
                        proptbl.Client4 = GetValue(dt, item, "Client4");
                        proptbl.Client5 = GetValue(dt, item, "Client5");
                        proptbl.Client6 = GetValue(dt, item, "Client6");
                        proptbl.Client7 = GetValue(dt, item, "Client7");
                        proptbl.Client8 = GetValue(dt, item, "Client8");
                        proptbl.Client9 = GetValue(dt, item, "Client9");
                        proptbl.Client10 = GetValue(dt, item, "Client10");
                        proptbl.Client11 = GetValue(dt, item, "Client11");
                        proptbl.Client12 = GetValue(dt, item, "Client12");
                        proptbl.Client13 = GetValue(dt, item, "Client13");
                        proptbl.Client14 = GetValue(dt, item, "Client14");
                        proptbl.Client15 = GetValue(dt, item, "Client15");
                        proptbl.code = GetValue(dt, item, "code");
                        //proptbl.condolvl = GetValue(dt, item, "condolvl");
                        //proptbl.dir = GetValue(dt, item, "dir");
                        proptbl.dista = GetValue(dt, item, "dista");
                        //proptbl.district = GetValue(dt, item, "district");
                        //proptbl.east = GetValue(dt, item, "east");
                        //proptbl.ed_amt = GetValue(dt, item, "ed_amt");
                        //proptbl.ext_wall = GetValue(dt, item, "ext_wall");
                        //proptbl.fireplace = GetValue(dt, item, "fireplace");
                        //proptbl.fld_dt = GetValue(dt, item, "fld_dt");
                        //proptbl.fld_pnl = GetValue(dt, item, "fld_pnl");
                        //proptbl.fld_zn = GetValue(dt, item, "fld_zn");
                        //proptbl.foundation = GetValue(dt, item, "foundation");
                        //proptbl.fron = GetValue(dt, item, "fron");
                        //proptbl.fuel_type = GetValue(dt, item, "fuel_type");
                        //proptbl.full_baths = GetValue(dt, item, "full_baths");
                        proptbl.garage = GetValue(dt, item, "garage");
                        //proptbl.half_baths = GetValue(dt, item, "half_baths");
                        //proptbl.heat_type = GetValue(dt, item, "heat_type");
                        proptbl.highlight = GetValue(dt, item, "highlight");
                        //proptbl.house_numb = GetValue(dt, item, "house_numb");
                        proptbl.ht_enc = GetValue(dt, item, "ht");
                        //proptbl.Id = GetValue(dt, item, "Client15");
                        //proptbl.irreg_desc = GetValue(dt, item, "irreg_desc");

                        proptbl.irregular = GetValue(dt, item, "irregular");
                        //proptbl.livunit = GetValue(dt, item, "livunit");
                        //proptbl.loc = GetValue(dt, item, "loc");
                        proptbl.lot = GetValue(dt, item, "lot");
                        proptbl.lot_acres = GetValue(dt, item, "lot_acres");
                        proptbl.lot_group = GetValue(dt, item, "lotgroup");
                        proptbl.lot_size = GetValue(dt, item, "logsize");
                        proptbl.lot1 = GetValue(dt, item, "lot1");
                        //proptbl.lspace = GetValue(dt, item, "lspace");
                        //proptbl.lsqft = GetValue(dt, item, "lsqft");
                        //proptbl.mailing_a1 = GetValue(dt, item, "mailing_a1");
                        //proptbl.mailing_ad = GetValue(dt, item, "mailing_ad");
                        //proptbl.mgfa = GetValue(dt, item, "mgfa");
                        //proptbl.new_dist = GetValue(dt, item, "new_dist");
                        //proptbl.north = GetValue(dt, item, "north");
                        //proptbl.old_name = GetValue(dt, item, "old_name");
                        //proptbl.owner_name = GetValue(dt, item, "owner_name");
                        //proptbl.prop_class = GetValue(dt, item, "prop_class");
                        //proptbl.rate_t = GetValue(dt, item, "rate_t");
                        //proptbl.ratio1 = GetValue(dt, item, "ratio1");
                        //proptbl.ratio2 = GetValue(dt, item, "ratio2");
                        //proptbl.ratio3 = GetValue(dt, item, "ratio3");
                        //proptbl.rec_no = GetValue(dt, item, "rec_no");
                        //proptbl.recno = GetValue(dt, item, "recno");
                        //proptbl.res_number = GetValue(dt, item, "res_number");
                        //proptbl.res_street = GetValue(dt, item, "res_street");
                        proptbl.rooms_bath = GetValue(dt, item, "rooms");
                        if (!proptbl.rooms_bath.Equals(string.Empty))
                        {
                            string laststr = proptbl.rooms_bath.Substring(proptbl.rooms_bath.LastIndexOf('/') + 1);
                            int lstr = 0;
                            if (int.TryParse(laststr, out lstr))
                            {
                                lstr = lstr % 2000;
                                proptbl.rooms_bath = proptbl.rooms_bath.Substring(0, proptbl.rooms_bath.LastIndexOf('/') + 1) + lstr.ToString();
                            }
                        }
                        proptbl.section = GetValue(dt, item, "sec");
                        //proptbl.src = GetValue(dt, item, "src");
                        //proptbl.st_name = GetValue(dt, item, "st_name");
                        //proptbl.st_swis_co = GetValue(dt, item, "st_swis_co");
                        //proptbl.state = GetValue(dt, item, "state");
                        //proptbl.str_ind = GetValue(dt, item, "str_ind");
                        //proptbl.street = GetValue(dt, item, "street");
                        proptbl.style = GetValue(dt, item, "style");
                        //proptbl.tax_class = GetValue(dt, item, "tax_class");
                        //proptbl.topo = GetValue(dt, item, "topo");
                        //proptbl.town_code = GetValue(dt, item, "town_code");
                        proptbl.township = GetValue(dt, item, "township");
                        //proptbl.traffic = GetValue(dt, item, "traffic");
                        proptbl.tsplit = GetValue(dt, item, "tsplit");
                        proptbl.unit = GetValue(dt, item, "unit_num");
                        //proptbl.util = GetValue(dt, item, "util");
                        //proptbl.village = GetValue(dt, item, "village");
                        //proptbl.wat_desc = GetValue(dt, item, "wat_desc");
                        //proptbl.waterfront = GetValue(dt, item, "waterfront");
                        proptbl.zip_code = GetValue(dt, item, "zip_code");
                        //proptbl.zip_code1 = GetValue(dt, item, "zip_code1");
                        #endregion
                        if (isnewEntry)
                        {
                            entity.Property_TBL.Add(proptbl);
                        }
                    }
                    catch (Exception ex)
                    {
                        string[] errlog = { DateTime.Now + " File Name:" + e.FullPath + " Exception:" + ex.Message + " Stack Trace:" + ex.StackTrace };
                        File.AppendAllLines(ConfigurationManager.AppSettings["LogFile"], errlog);
                    }
                    //entity.Property_TBL.Add(proptbl);
                }
                entity.SaveChanges();
                if (!File.Exists(ConfigurationManager.AppSettings["OutputPath"] + e.Name))
                {
                    System.IO.File.Move(e.FullPath, ConfigurationManager.AppSettings["OutputPath"] + e.Name);
                }
                else
                {
                    File.Delete(ConfigurationManager.AppSettings["OutputPath"] + e.Name);
                    System.IO.File.Move(e.FullPath, ConfigurationManager.AppSettings["OutputPath"] + e.Name);
                }
                AddToCSV(e.Name + "," + insertedCount.ToString() + "," + updatedCount.ToString() + "," + starttime.ToString("yyyy-MM-ddTHH':'mm':'sszzz") + "," + DateTime.Now.ToString("yyyy-MM-ddTHH':'mm':'sszzz"));
            }
            catch (Exception ex)
            {
                string[] errlog = { DateTime.Now + " File Name:" + e.FullPath + " Exception:" + ex.Message + " Stack Trace:" + ex.StackTrace };
                File.AppendAllLines(ConfigurationManager.AppSettings["ErrorLogFile"], errlog);
            }
        }

        private DataTable GetDateTableFromCSV(string strFilePath)
        {
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                DataTable dt = new DataTable();
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }

        private void AddToCSV(string logdata)
        {
            if (File.Exists(ConfigurationManager.AppSettings["LogFile"]))
            {
                string[] content = { logdata };
                File.AppendAllLines(ConfigurationManager.AppSettings["LogFile"], content);
            }
            else
            {
                string[] content = {"File Name, Inserted Count, Updated Count, Start Time, End Time", logdata};
                File.AppendAllLines(ConfigurationManager.AppSettings["LogFile"], content);
            }
        }
    }
}
