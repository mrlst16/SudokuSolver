import { FC } from "react";
import {MapSolverStrategyToString} from "../mappers/SolverStrategyTypeMapper"
import { Move } from "../models/Move";
import "../styles/MovesTable.css"

interface MovesTableProps{
    Moves: Move[]
}

const MovesTable : FC<MovesTableProps> = ({Moves})=>{
    if(Moves == undefined || Moves.length == 0)
        return (<></>)

    return (
        <div className="moves">
        <table className="movesTable">
            <th>Order</th>
            <th>Strategy</th>
            <th>Value</th>
            <th>Row</th>
            <th>Column</th>
            {
                Moves.map((m)=> 
                <tr>
                    <td>{m.order}</td>
                    <td>{
                            MapSolverStrategyToString(m.type)
                        }
                    </td>
                    <td>{m.value}</td>
                    <td>{m.i}</td>
                    <td>{m.j}</td>
                </tr>
                )
            }
        </table>
    </div>
    );
}

export default MovesTable;