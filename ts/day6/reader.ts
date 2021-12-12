import * as fs from 'fs';
import {LanternFish} from "./fish";

export function readFish(filePath: string): LanternFish[] {
    return fs.readFileSync(filePath, 'utf8')
        .split(',')
        .map(n => ({daysUntilNewFish: Number(n)}));
}