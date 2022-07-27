#define DISALLOW_NULL_EQUATION_TERMS

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TypeChecker
{
    internal class ConjunctionConstraint : TypeConstraint, IEnumerable<TypeConstraint>
    {
                public IEnumerable<TypeConstraint> Constraints { get; private set; }

        public ConjunctionConstraint(TypeConstraint left, TypeConstraint right)
        {
            Constraints = new[] { left, right };
        }

        public ConjunctionConstraint(IEnumerable<TypeConstraint> constraints)
        {
            Constraints = constraints;
        }

        public override string ToString() => string.Join(" ∧ ", Constraints.Select(t => t.ToString()));

        public IEnumerator<TypeConstraint> GetEnumerator()
        {
            return Constraints.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Constraints).GetEnumerator();
        }

        public override TypeConstraint Simplify(Substitution subst, IEnumerable<Yarn.TypeBase> knownTypes)
        {
            // TODO: simplify conjunctions by elimiminating redundant terms
            return this;
        }
    }
}