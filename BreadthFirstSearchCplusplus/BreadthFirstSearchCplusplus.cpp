#include<iostream>
#include<vector>
#include<queue>
#include<stack>
using namespace std;
void edge(vector<int>adj[], int u, int v) {
	adj[u].push_back(v);
}
void bfs(int s, vector<int>adj[], bool visit[]) {
	queue<int>q;
	q.push(s);
	visit[s] = true;
	while (!q.empty()) {
		int u = q.front();
		cout << u << " ";
		q.pop();
		for (int i = 0; i < adj[u].size(); i++) {
			if (!visit[adj[u][i]]) {
				q.push(adj[u][i]);
				visit[adj[u][i]] = true;
			}
		}
	}
}

int main() {
	vector<int>adj[11];
	bool visit[11];
	for (int i = 0; i < 11; i++) {
		visit[i] = false;
	}
	edge(adj, 1, 2);
	edge(adj, 1, 3);
	edge(adj, 2, 4);
	edge(adj, 4, 7);
	edge(adj, 3, 5);
	edge(adj, 3, 6);
	edge(adj, 5, 8);
	edge(adj, 8, 9);
	edge(adj, 9, 10);
	cout << "BFS traversal is" << "  ";
	bfs(1, adj, visit);
	cout << endl;
}
