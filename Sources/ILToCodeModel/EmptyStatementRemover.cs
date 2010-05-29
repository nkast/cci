﻿//-----------------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is licensed under the Microsoft Public License.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//-----------------------------------------------------------------------------
using System.Collections.Generic;
using Microsoft.Cci.MutableCodeModel;

namespace Microsoft.Cci.ILToCodeModel {
  internal class EmptyStatementRemover : BaseCodeTraverser {
    public override void Visit(IBlockStatement block) {
      base.Visit(block);
      BasicBlock bb = block as BasicBlock;
      if (bb != null)
        FindPattern(bb.Statements);
      return;
    }
    private static void FindPattern(List<IStatement> statements) {
      int n = statements.Count;
      for (int i = n - 1; 0 <= i; i--) {
        if (statements[i] is IEmptyStatement)
          statements.RemoveAt(i);
      }
      return;
    }
  }
}
