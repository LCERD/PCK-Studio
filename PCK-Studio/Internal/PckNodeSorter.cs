using OMI.Formats.Pck;
using PckStudio.Core.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PckStudio.Internal
{
    public class PckNodeSorter : IComparer, IComparer<TreeNode>
	{
		public object SortingOptions { get; set; } = null;
		public bool Descending { get; set; } = false;

		private bool CheckForSkinAndCapeFiles(TreeNode node)
		{
			return node.TryGetTagData(out PckAsset asset) &&
				(asset.Type == PckAssetType.SkinFile || asset.Type == PckAssetType.CapeFile);
		}

        public int Compare(object x, object y)
        {
			if (x is TreeNode tx && y is TreeNode ty)
				return Compare(tx, ty);
			return 0;
        }

        public int Compare(TreeNode x, TreeNode y)
		{
			int result = InternalCompare(x, y);
			//Debug.WriteLine(result);
			if (Descending && result != 0)
            {
                result = 2 % result + 1;
            }
            return result;
		}

        private int InternalCompare(TreeNode first, TreeNode second)
        {
            bool firstIsFile = first.IsTagOfType<PckAsset>();
            bool secondIsFile = second.IsTagOfType<PckAsset>();

            // Put folders first
            if (!firstIsFile && secondIsFile)
                return -1;
            if (firstIsFile && !secondIsFile)
                return 1;

            bool firstIsSkinOrCape = CheckForSkinAndCapeFiles(first);
            bool secondIsSkinOrCape = CheckForSkinAndCapeFiles(second);

            // Skins and capes after the rest for simplicity
            if (firstIsSkinOrCape && !secondIsSkinOrCape)
                return 1;
            if (!firstIsSkinOrCape && secondIsSkinOrCape)
                return -1;

            // Don't change order if both are skin related files
            if (firstIsSkinOrCape && secondIsSkinOrCape)
                return 0;

            // Sort the rest alpha-numerically
            return string.Compare(first.Text, second.Text, StringComparison.OrdinalIgnoreCase);
        }
    }

}