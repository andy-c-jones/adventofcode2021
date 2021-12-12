import {readFish} from "./reader";

describe("readFish", () => {
    it("should parse the give file and return a list of fish", () => {
        let expected = [
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 3
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 4
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 1
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 2
            },
        ];
        let actual = readFish('day6/testInput.txt');
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });
});

