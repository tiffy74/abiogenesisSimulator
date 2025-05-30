using System.Collections.Generic;

namespace AbiogenesisSimulator
{
    public static class ReactionLibrary
    {
        public static Dictionary<string, List<Reaction>> Presets = new()
        {
            // Inspired by deep-sea alkaline vents (like Lost City)
            ["Hydrothermal Vent"] = new List<Reaction>
            {
                new Reaction { Name = "Thioester Formation", InputEnergy = 8, OutputEnergy = 3, StorageEnergy = 4 },
                new Reaction { Name = "Proton Gradient Utilization", InputEnergy = 5, OutputEnergy = 6, StorageEnergy = 1 }
            },
            // Simulates wet-dry cycles from evaporation
            ["Tidal Pool"] = new List<Reaction>
            {
                new Reaction { Name = "Dehydration Polymerization", InputEnergy = 12, OutputEnergy = 2, StorageEnergy = 5 },
                new Reaction { Name = "Lipid Vesicle Formation", InputEnergy = 6, OutputEnergy = 1, StorageEnergy = 6 }
            },
            // UV Surface Pool: Simulates shallow pools on early Earth that were exposed to ultraviolet light.
            ["UV Surface Pool"] = new List<Reaction>
            {
                new Reaction { Name = "UV-Induced Bond Formation", InputEnergy = 10, OutputEnergy = 4, StorageEnergy = 3 },
                new Reaction { Name = "Photodissociation Cleanup", InputEnergy = 4, OutputEnergy = 2, StorageEnergy = 1 }
            },
            // Overloaded Network: Reactions here demand too much energy and collapse in environments with dips or irregularity
            ["Overloaded Network"] = new List<Reaction>
            {
                new Reaction { Name = "ATP-Like Synthesis", InputEnergy = 15, OutputEnergy = 2, StorageEnergy = 1 },
                new Reaction { Name = "Chain Assembly", InputEnergy = 12, OutputEnergy = 1, StorageEnergy = 2 }
                // Lesson: High - demand systems only survive if energy is consistently high.
            },
            // False Start: These reactions work only during the early chaotic phase of the Sun’s life (lots of noise),
            // but not when it stabilizes.
            ["False Start"] = new List<Reaction>
            {
                new Reaction { Name = "Photoactivation", InputEnergy = 9, OutputEnergy = 4, StorageEnergy = 0 },
                new Reaction { Name = "Radical Capture", InputEnergy = 7, OutputEnergy = 2, StorageEnergy = 1 }
                // Lesson: Viability can be temporary depending on star phase.
            },
            // Catastrophe Vulnerable: Appears stable, but cannot handle sudden drops in energy like those caused by asteroid impacts
            // or volcanic winters.
            ["Catastrophe Vulnerable"] = new List<Reaction>
            {
                new Reaction { Name = "Fine-Tuned Loop", InputEnergy = 6, OutputEnergy = 4, StorageEnergy = 3 },
                new Reaction { Name = "High Yield Branch", InputEnergy = 7, OutputEnergy = 5, StorageEnergy = 1 }
                // Lesson: Even good systems need resilience to survive big shocks.
            },
            // Storage Dependency: Stores a lot of energy in product molecules but fails when a sudden drop demands immediate energy output.
            ["Storage Dependency"] = new List<Reaction>
            {
                new Reaction { Name = "Polymer Accumulation", InputEnergy = 8, OutputEnergy = 1, StorageEnergy = 6 },
                new Reaction { Name = "Capstone Reaction", InputEnergy = 9, OutputEnergy = 1, StorageEnergy = 2 }
                //Lesson: Storage is not enough — energy must be accessible and timely.
            },


        };
    }
}