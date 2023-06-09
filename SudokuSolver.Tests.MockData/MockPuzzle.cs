using SudokuSolver.Models;

namespace SudokuSolver.Tests.MockData
{
    public class MockPuzzle
    {
        public static SudokuPuzzle SolvedPuzzle => new Cell[9, 9]
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        public static SudokuPuzzle PuzzleI7J2Missing => new Cell[,]
        {
            { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 0, 9, 1, 2, 3, 4, 5 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        public static SudokuPuzzle PuzzleRow0Missing => new Cell[,]
        {
            { 0, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 0, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 0, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 0, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 0, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 0, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 0, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 0, 7, 0, 9, 1, 2, 3, 4, 5 },
            { 0, 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        public static SudokuPuzzle PuzzleColumn0Missing => new Cell[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 0, 9, 1, 2, 3, 4, 5 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        public static SudokuPuzzle PuzzleSquare0Missing => new Cell[,]
        {
            { 0, 0, 0, 4, 5, 6, 7, 8, 9 },
            { 0, 0, 0, 7, 8, 9, 1, 2, 3 },
            { 0, 0, 0, 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            { 6, 7, 0, 9, 1, 2, 3, 4, 5 },
            { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        };

        public static SudokuPuzzle SporadicMissingPuzzle => new Cell[9, 9]
        {
            { 0, 2, 3, 0, 5, 0, 0, 8, 0 },
            { 4, 5, 0, 0, 8, 0, 1, 0, 0 },
            { 0, 8, 9, 1, 2, 3, 4, 5, 6 },
            { 2, 3, 4, 5, 6, 7, 8, 9, 0 },
            { 0, 6, 0, 8, 9, 0, 2, 3, 4 },
            { 8, 9, 1, 0, 3, 4, 0, 6, 0 },
            { 0, 4, 0, 0, 0, 0, 9, 1, 0 },
            { 6, 7, 0, 9, 1, 0, 3, 0, 5 },
            { 0, 1, 2, 3, 0, 5, 0, 7, 8 }
        };

        //From readers digest
        public static SudokuPuzzle EasyLevelPuzzle1 => new Cell[9, 9]
        {
            { 8, 0, 6, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 3, 0, 6, 4, 0, 9, 0 },
            { 9, 0, 0, 0, 0, 0, 8, 1, 6 },
            { 0, 8, 0, 3, 9, 6, 0, 0, 0 },
            { 7, 0, 2, 0, 4, 0, 3, 0, 9 },
            { 0, 0, 0, 5, 7, 2, 0, 8, 0 },
            { 5, 2, 1, 0, 0, 0, 0, 0, 4 },
            { 0, 3, 0, 7, 5, 0, 2, 0, 0 },
            { 0, 0, 0, 0, 2, 0, 1, 0, 5 }
        };

        //From readers digest
        public static SudokuPuzzle EasyLevelPuzzle1Solution => new Cell[9, 9]
        {
            { 8, 5, 6, 9, 1, 7, 4, 2, 3 },
            { 2, 1, 3, 8, 6, 4, 5, 9, 7 },
            { 9, 4, 7, 2, 3, 5, 8, 1, 6 },
            { 1, 8, 5, 3, 9, 6, 7, 4, 2 },
            { 7, 6, 2, 1, 4, 8, 3, 5, 9 },
            { 3, 9, 4, 5, 7, 2, 6, 8, 1 },
            { 5, 2, 1, 6, 8, 3, 9, 7, 4 },
            { 4, 3, 9, 7, 5, 1, 2, 6, 8 },
            { 6, 7, 8, 4, 2, 9, 1, 3, 5 }
        };

        //From readers digest
        public static SudokuPuzzle HardLevelPuzzle1 => new Cell[9, 9]
        {
            { 0, 0, 6, 5, 0, 0, 0, 0, 8 },
            { 0, 9, 5, 0, 0, 0, 0, 2, 0 },
            { 7, 0, 0, 9, 0, 0, 3, 0, 0 },
            { 0, 0, 0, 0, 4, 0, 2, 7, 0 },
            { 0, 0, 0, 8, 7, 3, 0, 0, 0 },
            { 0, 7, 9, 0, 5, 0, 0, 0, 0 },
            { 0, 0, 2, 0, 0, 8, 0, 0, 9 },
            { 0, 5, 0, 0, 0, 0, 8, 1, 0 },
            { 3, 0, 0, 0, 0, 5, 4, 0, 0 }
        };

        //From readers digest
        public static SudokuPuzzle HardLevelPuzzle1Solution => new Cell[9, 9]
        {
            { 1, 3, 6, 5, 2, 4, 7, 9, 8 },
            { 8, 9, 5, 3, 6, 7, 1, 2, 4 },
            { 7, 2, 4, 9, 8, 1, 3, 5, 6 },
            { 5, 8, 3, 6, 4, 9, 2, 7, 1 },
            { 2, 6, 1, 8, 7, 3, 9, 4, 5 },
            { 4, 7, 9, 1, 5, 2, 6, 8, 3 },
            { 6, 4, 2, 7, 1, 8, 5, 3, 9 },
            { 9, 5, 7, 4, 3, 6, 8, 1, 2 },
            { 3, 1, 8, 2, 9, 5, 4, 6, 7 }
        };

        //From readers digest
        public static SudokuPuzzle MediumLevelPuzzle1 => new Cell[9, 9]
        {
            { 5, 0, 7, 2, 0, 0, 0, 9, 0 },
            { 0, 0, 6, 0, 3, 0, 7, 0, 1 },
            { 4, 0, 0, 0, 0, 0, 0, 6, 0 },
            { 1, 0, 0, 4, 9, 0, 0, 0, 7 },
            { 0, 0, 0, 5, 0, 8, 0, 0, 0 },
            { 8, 0, 0, 0, 2, 7, 0, 0, 5 },
            { 0, 7, 0, 0, 0, 0, 0, 0, 9 },
            { 2, 0, 9, 0, 8, 0, 6, 0, 0 },
            { 0, 4, 0, 0, 0, 9, 3, 0, 8 }
        };

        //From readers digest
        public static SudokuPuzzle MediumLevelPuzzle1Solution => new Cell[9, 9]
        {
            { 5, 1, 7, 2, 6, 4, 8, 9, 3 },
            { 9, 2, 6, 8, 3, 5, 7, 4, 1 },
            { 4, 8, 3, 9, 7, 1, 5, 6, 2 },
            { 1, 3, 5, 4, 9, 6, 2, 8, 7 },
            { 7, 9, 2, 5, 1, 8, 4, 3, 6 },
            { 8, 6, 4, 3, 2, 7, 9, 1, 5 },
            { 3, 7, 8, 6, 4, 2, 1, 5, 9 },
            { 2, 5, 9, 1, 8, 3, 6, 7, 4 },
            { 6, 4, 1, 7, 5, 9, 3, 2, 8 }
        };

        public static SudokuPuzzle EasyLevelPuzzle1After11Moves => new Cell[9, 9]
        {
            { 5, 0, 7, 2, 0, 0, 0, 9, 3 },
            { 9, 2, 6, 8, 3, 0, 7, 0, 1 },
            { 4, 0, 0, 0, 0, 0, 0, 6, 2 },
            { 1, 0, 0, 4, 9, 0, 0, 0, 7 },
            { 7, 0, 0, 5, 1, 8, 0, 0, 6 },
            { 8, 0, 0, 0, 2, 7, 0, 0, 5 },
            { 3, 7, 0, 0, 0, 0, 0, 0, 9 },
            { 2, 0, 9, 0, 8, 0, 6, 0, 4 },
            { 6, 4, 0, 0, 0, 9, 3, 0, 8 }
        };
    }
}
