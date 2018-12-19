using System;
using System.Collections.Generic;
using System.Drawing;

namespace TetrisDb
{
    public abstract class Tetramino : ICloneable
    {
        protected List<int[,]> BlockPositions;
        private int Rotation;
        public Point Position;

        public int[,] Block => BlockPositions[Rotation];

        public void Rotate()
        {
            Rotation = (Rotation + 1) % 4;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class I : Tetramino
    {
        public I()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 1, 1},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 1, 1},
                    {0, 0, 0, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                }
            };
        }
    }
    public class J : Tetramino
    {
        public J()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 0, 0, 0},
                    {1, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 1, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 1, 0},
                    {0, 0, 1, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {1, 1, 0, 0}
                }
            };
        }
    }
    public class L : Tetramino
    {
        public L()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 1, 0},
                    {1, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 1, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 1, 0},
                    {1, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 0, 0}
                }
            };
        }
    }
    public class O : Tetramino
    {
        public O()
        {
            Position = new Point(5, 23);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {1, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {1, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {1, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {1, 1, 0, 0}
                }
            };
        }
    }
    public class S : Tetramino
    {
        public S()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 1, 0},
                    {1, 1, 0, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 1, 0},
                    {0, 0, 1, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {0, 1, 1, 0},
                    {1, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 0, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 0, 0}
                }
            };
        }
    }
    public class T : Tetramino
    {
        public T()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {1, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {0, 1, 1, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 1, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 0, 0}
                }
            };
        }
    }
    public class Z : Tetramino
    {
        public Z()
        {
            Position = new Point(5, 21);

            BlockPositions = new List<int[,]>
            {
                new[,]
                {
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 1, 0},
                    {0, 0, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 1, 0},
                    {0, 1, 1, 0},
                    {0, 1, 0, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 0, 0, 0},
                    {1, 1, 0, 0},
                    {0, 1, 1, 0}
                },
                new[,]
                {
                    {0, 0, 0, 0},
                    {0, 1, 0, 0},
                    {1, 1, 0, 0},
                    {1, 0, 0, 0}
                }
            };
        }
    }

}
