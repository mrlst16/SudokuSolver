import { Move } from "./Move";

export class SudokuAnalyticsResponse{
    totalPasses: number = -1;
    stringRepresentation: string = "";
    moves: Move[] = [];
    solvedPuzzle: number[] = [];
    solvedPuzzle2D: number[][] = [[]];
}