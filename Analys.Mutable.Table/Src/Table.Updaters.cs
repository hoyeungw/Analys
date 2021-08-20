﻿using System.Collections.Generic;
using Veho.List;

namespace Analys.Mutable {
  public partial class Table<T> {
    public Table<T> PushRow(List<T> vec) {
      Rows.Add(vec);
      return this;
    }
    public Table<T> PushColumn(List<T> vec) {
      Rows.Iterate((i, row) => row.Add(vec[i]));
      return this;
    }
  }
}