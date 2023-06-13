import { SolverStrategyType } from "./SolverStrategyType";

export class Move{
    order: number = -1;
    i : number = -1;
    j: number = -1;
    value: number = -1;
    type: SolverStrategyType = SolverStrategyType.None;
}