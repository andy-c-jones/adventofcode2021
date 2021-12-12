import {readCrabPositions} from "./reader";

describe("readCrabPositions", () => {
    it("should parse the give file and return a list of numbers", () => {
        let expected = [16, 1, 2, 0, 4, 2, 7, 1, 2, 14];
        let actual = readCrabPositions('day7/testInput.txt');
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });
});

