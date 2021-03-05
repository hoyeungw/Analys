﻿using System;
using Veho.Matrix;
using Veho.Vector;

namespace Analys {
  public class DataGram<T> {
    protected string[] Side;
    protected string[] Head;
    protected T[][] Rows;
    protected Func<T> Init;
    public static DataGram<T> Build(Func<T> init) => new DataGram<T> {
      Side = new string[] { },
      Head = new string[] { },
      Rows = new T[][] { },
      Init = init
    };
    public int IndexSide(string x) {
      var ri = this.Side.IndexOf(x);
      if (ri >= 0) return ri;
      Ext.PushRow(ref this.Rows, Vec.Init(this.Rows.Width(), j => this.Init()));
      return ri + Vec.Push(ref this.Side, x);
    }
    public int IndexHead(string y) {
      var ci = this.Head.IndexOf(y);
      if (ci >= 0) return ci;
      Ext.PushColumn(ref this.Rows, Vec.Init(this.Rows.Height(), i => this.Init()));
      return ci + Vec.Push(ref this.Head, y);
    }
    public (string[] side, string[] head, T[,] rows) ToTuple() => (
      this.Side,
      this.Head,
      this.Rows.NestToMatrix()
    );
    public (string[] side, string[] head, TO[,] rows) ToTuple<TO>() => (
      this.Side,
      this.Head,
      this.Rows.NestToMatrix().CastTo<T, TO>()
    );
  }
}