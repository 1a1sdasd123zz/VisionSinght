using System;
using System.Linq;
using System.Windows.Forms;
using VisionCore.Solution;

namespace VisionCore.GlobarValue
{
    public partial class Frm_GlobalVar : Form
    {
        private readonly SolutionManager _mgr = SolutionManager.Instance;
        public Frm_GlobalVar()
        {
            InitializeComponent();
            Load += (s,e)=>RefreshGrid();
            btn_AddInt.Click += (s,e)=> { _mgr.AddGlobalVariable(typeof(int)); RefreshGrid(); };
            btn_AddDouble.Click += (s,e)=> { _mgr.AddGlobalVariable(typeof(double)); RefreshGrid(); };
            btn_AddString.Click += (s,e)=> { _mgr.AddGlobalVariable(typeof(string)); RefreshGrid(); };
            btn_AddBool.Click += (s,e)=> { _mgr.AddGlobalVariable(typeof(bool)); RefreshGrid(); };
            btn_AddIntArray.Click += (s,e)=> { _mgr.AddGlobalVariable(typeof(int[])); RefreshGrid(); };
            btn_AddDoubleArray.Click += (s,e)=> { _mgr.AddGlobalVariable(typeof(double[])); RefreshGrid(); };
            btn_AddStringArray.Click += (s,e)=> { _mgr.AddGlobalVariable(typeof(string[])); RefreshGrid(); };
            btn_AddBoolArray.Click += (s,e)=> { _mgr.AddGlobalVariable(typeof(bool[])); RefreshGrid(); };
            btn_Remove.Click += (s,e)=>RemoveSelected();
            btn_Confirm.Click += (s,e)=> { ApplyEdits(); Close(); };
            btn_Cancel.Click += (s,e)=>Close();
            dataGridView1.CellEndEdit += (s,e)=>ApplyRow(e.RowIndex);
        }
        private string GetDisplayTypeName(string storedType)
        {
            if (string.IsNullOrWhiteSpace(storedType)) return storedType;
            try
            {
                var t = Type.GetType(storedType, false);
                if (t == null) return storedType; // fallback
                bool isArray = t.IsArray;
                if (isArray) t = t.GetElementType();
                string core = t == typeof(int) ? "int" :
                              t == typeof(double) ? "double" :
                              t == typeof(string) ? "string" :
                              t == typeof(bool) ? "bool" : t.Name;
                return isArray ? core + "[]" : core;
            }
            catch { return storedType; }
        }
        private void RefreshGrid()
        {
            dataGridView1.Rows.Clear();
            var vars = _mgr.GetGlobalVariables().ToList();
            for(int i=0;i<vars.Count;i++)
            {
                var v = vars[i];
                var typeName = GetDisplayTypeName(v.Type);
                dataGridView1.Rows.Add(i, typeName, v.Name, v.Value, v.Annotation ?? "");
            }
        }
        private void ApplyRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count) return;
            // column order: 0 Index, 1 Type, 2 Name, 3 Value, 4 Annotation
            var row = dataGridView1.Rows[rowIndex];
            var name = Convert.ToString(row.Cells[2].Value);
            var valueStr = Convert.ToString(row.Cells[3].Value);
            var annotation = Convert.ToString(row.Cells[4].Value);
            var list = _mgr.GetGlobalVariables().ToList();
            if (rowIndex >= list.Count) return;
            var gv = list[rowIndex];
            // 名称唯一校验
            if (!string.IsNullOrWhiteSpace(name) && !list.Where((x,idx)=>idx!=rowIndex).Any(x=>x.Name.Equals(name,StringComparison.OrdinalIgnoreCase)))
                gv.Name = name;
            gv.Value = string.IsNullOrWhiteSpace(valueStr)? null : valueStr;
            gv.Annotation = string.IsNullOrWhiteSpace(annotation)? null : annotation.Trim();
            _mgr.RegisterRuntimeToolForGlobals(); // rebuild registry for updated names/values
            RefreshGrid();
        }
        private void ApplyEdits()
        {
            for(int i=0;i<dataGridView1.Rows.Count;i++) ApplyRow(i);
        }
        private void RemoveSelected()
        {
            if (dataGridView1.SelectedRows.Count==0) return;
            var idx = dataGridView1.SelectedRows[0].Index;
            var list = _mgr.GetGlobalVariables().ToList();
            if (idx>=0 && idx<list.Count)
            {
                list.RemoveAt(idx); // not persisted until save; just adjust collection
                _mgr.CurrentSolution.Data.GlobalVariables = list; // assign back
                _mgr.RebuildGlobalVariableRegistry(); // rebuild registry for updated names/values
                RefreshGrid();
            }
        }
    }
}
