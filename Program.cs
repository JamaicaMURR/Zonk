using System.Runtime.CompilerServices;
using Zonk;

Cup cup = new Cup(0, 1);
BonesCombinator bonesCombinator = new BonesCombinator(cup);

for(int i = 0; i < 20; i++)
{
    int[] bones = cup.DropBones(3);

    Console.WriteLine(cup.AsString(bones));
    Console.WriteLine(bonesCombinator.AsString(bonesCombinator.Combinate(bones)));
}

Console.ReadKey();
