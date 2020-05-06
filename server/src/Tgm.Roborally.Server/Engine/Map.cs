﻿using System;
using System.Linq;
using System.Runtime.Serialization;
using Tgm.Roborally.Server.Models;
using Tgm.Roborally.Server.Models;

namespace Tgm.Roborally.Server.Engine
{
	[DataContract]
	public class Map
	{
		[DataMember] private Tile[,] Tiles; // Columns | Rows => Tiles[0][2] = 0 | 2

		[DataMember] private int ColumnCount = 10;

		public int Height => ColumnCount;
		public int Width => RowCount;

		public MapInfo Info => new MapInfo(this);

		public Position PrioCorePos
		{
			get
			{
				for (int y = 0; y < RowCount; y++)
				{
					for (int x = 0; x < ColumnCount; x++)
					{
						if (this[x, y].Type == TileType.PrioCore)
							return new Position(x, y);
					}
				}

				return null;
			}
		}

		[DataMember] private int RowCount = 10;


		public Tile this[int x, int y]
		{
			get { return Tiles[x, y]; }
			set
			{
				if (value.Type == TileType.PrioCore && PrioCoreCount > 0)
					throw new ArgumentException("Only one Prio Core per Map allowed");
				Tiles[x, y] = value;
			}
		}

		public Map(int columnCount = 10, int rowCount = 10) => Tiles = GetEmptyMap(columnCount, rowCount);

		public Tile[,] GetEmptyMap(int columnCount, int rowCount)
		{
			this.ColumnCount = columnCount;
			this.RowCount = rowCount;
			return GetEmptyMap();
		}

		public Tile[,] GetEmptyMap()
		{
			Tile[,] tiles = new Tile[ColumnCount, RowCount];

			for (int c = 0; c < ColumnCount; c++)
			{
				for (int r = 0; r < RowCount; r++)
				{
					tiles[c, r] = new Tile();
				}
			}

			return tiles;
		}


		public bool AddColumn(int index)
		{
			if (index < 0 || index > ColumnCount)
				return false;

			ColumnCount++;
			Tile[,] tiles = new Tile[ColumnCount, RowCount];
			for (int c = 0; c < ColumnCount; c++)
			{
				for (int r = 0; r < RowCount; r++)
				{
					if (c < index)
					{
						tiles[c, r] = Tiles[c, r];
					}
					else if (c > index)
					{
						tiles[c, r] = Tiles[c - 1, r];
					}
					else
					{
						tiles[c, r] = new Tile();
					}
				}
			}

			Tiles = tiles;

			return true;
		}

		public bool RemoveColumn(int index)
		{
			if (index < 0 || index >= ColumnCount)
				return false;

			ColumnCount--;
			Tile[,] tiles = new Tile[ColumnCount, RowCount];
			for (int c = 0; c < ColumnCount; c++)
			{
				for (int r = 0; r < RowCount; r++)
				{
					if (c < index)
					{
						tiles[c, r] = Tiles[c, r];
					}
					else if (c < index)
					{
						tiles[c, r] = Tiles[c + 1, r];
					}
					else
					{
						tiles[c, r] = new Tile();
					}
				}
			}

			Tiles = tiles;

			return true;
		}

		public bool AddRow(int index)
		{
			if (index < 0 || index > RowCount)
				return false;

			RowCount++;
			Tile[,] tiles = new Tile[ColumnCount, RowCount];
			for (int c = 0; c < ColumnCount; c++)
			{
				for (int r = 0; r < RowCount; r++)
				{
					if (r < index)
					{
						tiles[c, r] = Tiles[c, r];
					}
					else if (r > index)
					{
						tiles[c, r] = Tiles[c, r - 1];
					}
					else
					{
						tiles[c, r] = new Tile();
					}
				}
			}

			Tiles = tiles;

			return true;
		}

		public bool RemoveRow(int index)
		{
			if (index < 0 || index >= RowCount)
				return false;

			RowCount--;
			Tile[,] tiles = new Tile[ColumnCount, RowCount];
			for (int c = 0; c < ColumnCount; c++)
			{
				for (int r = 0; r < RowCount; r++)
				{
					if (r < index)
					{
						tiles[c, r] = Tiles[c, r];
					}
					else if (r > index)
					{
						tiles[c, r] = Tiles[c, r + 1];
					}
					else
					{
						tiles[c, r] = new Tile();
					}
				}
			}

			Tiles = tiles;

			return true;
		}

		public bool SwitchTiles(int x1, int y1, int x2, int y2)
		{
			if (ColumnCount <= x1 || RowCount <= y1 || ColumnCount <= x2 || RowCount <= y2)
				return false;

			Tile tile1 = Tiles[x1, y1];
			Tile tile2 = Tiles[x2, y2];

			Tiles[x1, y1] = tile2;
			Tiles[x2, y2] = tile1;

			return true;
		}

		public bool SwitchColumns(int column1, int column2)
		{
			if (ColumnCount <= column1 || ColumnCount <= column2)
				return false;

			for (int r = 0; r < RowCount; r++)
			{
				SwitchTiles(column1, r, column2, r);
			}

			return true;
		}

		public bool SwitchRows(int row1, int row2)
		{
			if (RowCount <= row1 || RowCount <= row2)
				return false;

			for (int c = 0; c < ColumnCount; c++)
			{
				SwitchTiles(c, row1, c, row2);
			}

			return true;
		}

		public int PrioCoreCount
		{
			get
			{
				int count = 0;
				for (int c = 0; c < ColumnCount; c++)
				{
					for (int r = 0; r < RowCount; r++)
					{
						if (Tiles[c, r].Type == TileType.PrioCore)
							count++;
					}
				}

				return count;
			}
		}


		public bool IsValid()
		{
			// Checks if all Tiles are set
			for (int c = 0; c < ColumnCount; c++)
			{
				for (int r = 0; r < RowCount; r++)
				{
					if (Tiles[c, r] == null)
						return false;
				}
			}

			// Checks if there is only one priority Beacon
			if (PrioCoreCount != 1)
				return false;

			return true;
		}

		public string ToMapString()
		{
			string mapString = "";
			for (int r = 0; r < RowCount + 1; r++)
			{
				for (int c = 0; c < ColumnCount + 1; c++)
				{
					if (r == RowCount)
					{
						if (c == 0)
						{
							mapString += "╚═══";
						}
						else if (c == ColumnCount)
						{
							mapString += "╝\n";
						}
						else
						{
							mapString += "╧═══";
						}
					}
					else
					{
						if (r == 0 && c == 0)
						{
							mapString += "╔═══";
						}
						else if (r == 0 && c == ColumnCount)
						{
							mapString += "╗\n";
						}
						else if (c == 0)
						{
							mapString += "╟═══";
						}
						else if (c == ColumnCount)
						{
							mapString += "╢\n";
						}
						else if (r == 0)
						{
							mapString += "╤═══";
						}
						else
						{
							mapString += "╬═══";
						}
					}
				}

				for (int c = 0; c < ColumnCount; c++)
				{
					if (r == RowCount)
					{
					}
					else
					{
						string value = ((int) Tiles[c, r].Type).ToString();
						mapString += "║";
						mapString += " ";
						mapString += value;
						mapString += new string(' ', 2 - value.Length);
						if (c == ColumnCount - 1)
							mapString += "║\n";
					}
				}
			}

			return mapString;
		}
	}
}