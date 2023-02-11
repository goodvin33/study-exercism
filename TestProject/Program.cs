
//using TestProject;
using System.Data;
using TestProject;

var whiteQueen = QueenAttack.Create(2, 4);
var blackQueen = QueenAttack.Create(2, 6);
QueenAttack.CanAttack(whiteQueen, blackQueen);