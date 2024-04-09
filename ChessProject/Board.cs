using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChessProject
{
    class Board
    {
        [Key]
        public int ID { get; set; }
        public int[,] Matrix { get; set; }
        public string Color { get; set; }
        public string Move { get; set; }
    }
}
