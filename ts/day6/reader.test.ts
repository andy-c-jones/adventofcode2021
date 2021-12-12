import {readFish} from "./reader";

describe("readFish", () => {
    it("should parse the give file and return a list of fish", () => {
        let expected = [
            {daysUntilNewFish: 3},
            {daysUntilNewFish: 4},
            {daysUntilNewFish: 3},
            {daysUntilNewFish: 1},
            {daysUntilNewFish: 2},
        ];
        let actual = readFish('day6/testInput.txt');
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });
});

