import { SolverStrategyType } from "../models/SolverStrategyType";

export function MapSolverStrategyToString(type: SolverStrategyType) : string{
    switch(type){
        case SolverStrategyType.SinglePossibilityPerCell:
            return "Only number that can go in cell";
        case SolverStrategyType.SinglePossibilityOfNumberInRow:
            return "Only instance of this number in this row";
        case SolverStrategyType.SinglePossibilityOfNumberInColumn:
            return "Only instance of this number in this column";
        case SolverStrategyType.SinglePossibilityOfNumberInSquare:
            return "Only instance of this number in this square";
            default:
                return "";
    }
}