import random
import math
import copy
import time
 
 
class Adjacency(object):
    """ 
    node: a list of one vertex, or contracted vertices.
 
    edge: a list of vertices that 'node' is adjacent to.
    """
 
    def __init__(self, node, edge):
        self.node = node
        self.edge = edge
 
    def contract(self, other):
        self.node += other.node
        self.edge = [i for i in self.edge + other.edge
                     if i not in self.node]
 
    def __repr__(self):
        return 'Adjacency(node = %r, edge = %r)' % (self.node, self.edge)
 
 
def cut(graph):
    """ Main algorithm. Returns two contracted Adjacency where graph is cut.
 
    graph: a list of Adjacency objects.
    """
    #while |V| > 2 do
    if len(graph) == 2:
        return graph
    else:
        #Get random edge(get 1 pick, get 2 pick)
        rand_pick = random.choice(graph)
        #choice second pick
        merge_node = random.choice(rand_pick.edge)
        #get second pick
        merge_pick = [i for i in graph if merge_node in i.node]
        #add new vertex and edges
        rand_pick.contract(merge_pick[0])
        #remove old vertex
        graph.remove(merge_pick[0])
        #return V
        return cut(graph)
 
 
def min_cut(graph):
    """Returns the graph cut where minimum crossing edges cut"""
 
    #with trail number n*n*ln(n), failure chance is 1/n
    trial_nu = int(math.pow(len(graph), 1) * math.log(len(graph)))
    min_cross = float('inf')
    for i in range(trial_nu):
        trial = cut(copy.deepcopy(graph))
        cut_cross = len(trial[0].edge)
        if cut_cross < min_cross:
            min_cross = cut_cross
            out = trial
    return out, min_cross

def read_graph(input_file):
    data = [[[int(line.split()[0])], [int(i) for i in line.split()[1:]]]
            for line in input_file]

    print data
    graph = [Adjacency(i[0], i[1]) for i in data]
    return graph

 
def main():
    graph_file = open('kargerMinCut.txt')   
    graph = read_graph(graph_file)
   
    return min_cut(graph)
 
 
if __name__ == '__main__':
    start = time.time()
    print main()
    print 'time = %r' %(time.time() - start)
