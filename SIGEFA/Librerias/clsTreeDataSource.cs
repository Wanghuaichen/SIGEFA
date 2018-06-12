using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using System.Collections;

namespace SIGEFA.Librerias
{
    public class clsTreeDataSource: TreeList.IVirtualTreeListData
    {
        protected clsTreeDataSource parentCore;
        protected ArrayList childrenCore = new ArrayList();
        protected object[] cellsCore;

        public clsTreeDataSource(clsTreeDataSource parent, object[] cells)
        {
            // Specifies the parent node for the new node. 
            this.parentCore = parent;
            // Provides data for the node's cell. 
            this.cellsCore = cells;
            if (this.parentCore != null) {
                this.parentCore.childrenCore.Add(this);
            }
        }
        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info) {
            info.Children = childrenCore;
        }
        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info) {
            info.CellData = cellsCore[info.Column.AbsoluteIndex];
        }
        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info) {
            cellsCore[info.Column.AbsoluteIndex] = info.NewCellData;
        }
    }
}
