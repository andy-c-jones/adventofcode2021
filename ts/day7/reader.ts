import * as fs from 'fs';

export function readCrabPositions(filePath: string): number[] {
    return fs.readFileSync(filePath, 'utf8')
        .split(',')
        .map(Number);
}
