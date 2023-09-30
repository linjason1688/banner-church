<template>
  <q-page class="q-pa-md">
    <q-breadcrumbs class="q-mb-md c-content-body">
      <q-breadcrumbs-el v-for="breadcrumb in ['系統管理', '聚會點組織管理', '台中市旌旗教會']" :key="breadcrumb" :label="breadcrumb" />
    </q-breadcrumbs>
    <q-separator vertical spaced="xl" />
    <div v-if="!editable" class="flex items-center q-gutter-sm bg-grey-2 q-px-md q-py-sm">
      <c-column label="隸屬組織">
        <q-breadcrumbs>
          <q-breadcrumbs-el v-for="org in selfOrganizationRoute" :key="org" :label="org" />
        </q-breadcrumbs>
      </c-column>
      <q-space />
      <q-separator vertical />
      <c-column label="選擇協會">
        <FormOrganization v-model="selectedOrganization" outlined dense class="c-bgcolor-gray-white"
          @update:model-value="selfOrganizationRoute = findSelfOrganizationRoute(selectedOrganization)" />
      </c-column>
      <q-btn color="indigo" rounded @click="editable = true">編輯組織圖</q-btn>
      <q-btn color="indigo" rounded>匯出</q-btn>
    </div>
    <q-btn v-if="!editable" class="q-ma-md" color="indigo" round icon="add" @click="createDialog = true" />
    <!-- <div ref="containerRef" style="height:1000px"></div> -->
    <OrgChart v-for="item in orgTree.children" :key="item.id" :item="item" :level="0" :editable="editable" class="justify-center"
      @add="organizationList.push({ id: organizationList.length, name: '', upperOrganizationId: $event.id, isInput: true })"
      @remove="organizationList = organizationList.filter(x => x.id != $event.id)" />
    <div v-if="editable" class="column q-gutter-sm q-pa-sm bg-grey-2" style="position:fixed;top:30%;right:0">
      <q-btn color="indigo" rounded @click="confirmSave">確定</q-btn>
      <q-btn color="indigo" outline rounded @click="confirmCancel">取消</q-btn>
    </div>
    <q-dialog v-model="createDialog">
      <q-card class="c-dialog-card q-pa-md">
        <q-card-section>
          <div class="c-content-title">請輸入協會名稱</div>
        </q-card-section>
        <q-card-section class="q-pt-none">
          <q-input outlined v-model="newOrganizationName" placeholder="請輸入協會名稱" dense />
        </q-card-section>
        <q-card-section class="q-pt-none row justify-end q-gutter-sm">
          <q-btn v-close-popup rounded unelevated label="取消" class="c-button-lg c-primary-color-400 c-bgcolor-gray-white"
            padding="sm lg" outline />
          <q-btn v-close-popup rounded unelevated label="新增" class="c-button-lg c-text-color-white c-primary-bgcolor-400"
            padding="sm lg" @click="createAssociation" />
        </q-card-section>
      </q-card>
    </q-dialog>
  </q-page>
</template>

<script lang="ts">
import { Vue } from "vue-class-component";
import { Options } from "vue-class-component";
import FormOrganization from "components/business/FormOrganization.vue";
import { FetchAllOrganizationRequest, OrganizationView, CreateOrganizationCommand, UpdateOrganizationCommand } from "src/api/feature/api";
import "@antv/x6-vue-shape"
import { Graph, Node, Cell, Edge, Dom } from "@antv/x6"
import dagre from "dagre"
import OrgChart, { Org, Org2Tree } from "src/components/elementary/OrgChart.vue";
import { WithLoading } from "src/util/TsDecorators";


@Options({
  components: {
    FormOrganization,
    OrgChart,
  },
})
export default class Index extends Vue {
  selectedOrganization = null;
  newOrganizationName = "";
  selfOrganizationRoute: Array<string | undefined> = [];
  createDialog = false;
  editable = false;
  beforeEdit = [] as OrganizationView[];
  organizationList = [] as OrganizationView[];
  /* eslint-disable */
  get orgTree(): Org {
    return Org2Tree(this.organizationList as Org[]);
  }
  /* eslint-disable */
  initAntvX6() {
    let vthis = this;
    let dir = "LR" // LR RL TB BT;
    const containerRef = this.$refs.containerRef
    const graph = new Graph({ container: containerRef as HTMLElement, width: 1000, height: 2000, })
    Graph.registerNode(
      "org-node",
      {
        width: 150,
        height: 60,
        markup: [
          { tagName: "rect", attrs: { class: "card", }, },
          { tagName: "text", attrs: { class: "name", }, },
          {
            tagName: "g",
            attrs: { class: "btn add", },
            children: [
              { tagName: "circle", attrs: { class: "add", }, },
              { tagName: "text", attrs: { class: "add", }, },
            ],
          },
          {
            tagName: "g",
            attrs: { class: "btn del", },
            children: [
              { tagName: "circle", attrs: { class: "del", }, },
              { tagName: "text", attrs: { class: "del", }, },
            ],
          },
        ],
        attrs: {
          text: { text: "", },
          ".card": { rx: 4, ry: 4, refWidth: "100%", refHeight: "100%", fill: "#ffffff", stroke: "#D2D3D4", strokeWidth: 1, pointerEvents: "visiblePainted", },
          ".name": { refX: 0.5, refY: 0.5, fill: "#282828", fontFamily: "Arial", fontSize: 15, fontWeight: "400", textAnchor: "middle", textVerticalAnchor: 'middle', },
          ".btn.add": { refDx: 0, refY: 0, event: "node:add", },
          ".btn.del": { refDx: -28, refY: 0, event: "node:delete", },
          ".btn.add > circle": { r: 10, fill: "#FFFFFF", stroke: "#3764AC", strokeWidth: 1, },
          ".btn.del > circle": { r: 10, fill: "#FFFFFF", stroke: "#D01526", strokeWidth: 1, },
          ".btn.add > text": { fontSize: 20, fontWeight: 800, fill: "#3764AC", x: -5.5, y: 7, fontFamily: "Times New Roman", text: "+", },
          ".btn.del > text": { fontSize: 28, fontWeight: 500, fill: "#D01526", x: -4.5, y: 6, fontFamily: "Times New Roman", text: "-", },
        },
      },
      true,
    )

    Graph.registerEdge(
      "org-edge",
      {
        zIndex: -1,
        attrs: { line: { strokeWidth: 2, stroke: "#D2D3D4", sourceMarker: null, targetMarker: null, }, },
      },
      true,
    )

    function setup() {
      graph.on('node:add', (args: any) => {
        console.log(args);
        args.e.stopPropagation()
        const member = createNode(-1, "new organization")
        // graph.freeze()
        graph.addCell([member, createEdge(args.node, member)])
        layout()
      })
      graph.on('node:delete', (args: any) => {
        args.e.stopPropagation()
        console.log(args);
        // graph.freeze()
        graph.removeCell(args.node)
        layout()
      })

      graph.on('node:dblclick', ({ cell, e }) => {
        const name = "node-editor"
        cell.removeTool("")
        cell.addTools({ name, args: { event: e, }, })
      })
      graph.on('node:changed', async ({ cell, options }) => {
        if (options.propertyValue != undefined && options.propertyValue != "") {
          let findOrganization = vthis.organizationList.find(x => x.id == cell.data.organizationId)
          let organization = {} as OrganizationView;
          if (findOrganization === undefined) return
          organization = findOrganization;
          if (organization.name != options.propertyValue) {
            organization.name = options.propertyValue;
            await vthis.putOrganizations(organization);
          }
        }
      })
    }

    function layout() {
      const nodes = graph.getNodes()
      const edges = graph.getEdges()
      const g = new dagre.graphlib.Graph()
      g.setGraph({ rankdir: dir, nodesep: 16, ranksep: 16 })
      g.setDefaultEdgeLabel(() => ({}))

      const width = 260
      const height = 90
      nodes.forEach((node) => {
        g.setNode(node.id, { width, height })
      })

      edges.forEach((edge) => {
        const source = edge.getSourceCellId()
        const target = edge.getTargetCellId()
        g.setEdge(source, target)
      })

      dagre.layout(g)

      // graph.freeze()

      g.nodes().forEach((id) => {
        const node = graph.getCellById(id) as unknown as Node
        if (node) {
          const pos = g.node(id)
          node.position(pos.x, pos.y)
        }
      })

      edges.forEach((edge) => {
        const source = edge.getSourceNode()!
        const target = edge.getTargetNode()!
        const sourceBBox = source.getBBox()
        const targetBBox = target.getBBox()

        if ((dir === "LR" || dir === "RL") && sourceBBox.y !== targetBBox.y) {
          const gap =
            dir === "LR"
              ? targetBBox.x - sourceBBox.x - sourceBBox.width
              : -sourceBBox.x + targetBBox.x + targetBBox.width
          const fix = dir === "LR" ? sourceBBox.width : 0
          const x = sourceBBox.x + fix + gap / 2
          edge.setVertices([
            { x, y: sourceBBox.center.y },
            { x, y: targetBBox.center.y },
          ])
        } else if (
          (dir === "TB" || dir === "BT") &&
          sourceBBox.x !== targetBBox.x
        ) {
          const gap =
            dir === "TB"
              ? targetBBox.y - sourceBBox.y - sourceBBox.height
              : -sourceBBox.y + targetBBox.y + targetBBox.height
          const fix = dir === "TB" ? sourceBBox.height : 0
          const y = sourceBBox.y + fix + gap / 2
          edge.setVertices([
            { x: sourceBBox.center.x, y },
            { x: targetBBox.center.x, y },
          ])
        } else {
          edge.setVertices([])
        }
      })

      // graph.unfreeze()
    }

    function createNode(id: number, name: string) {
      return graph.createNode({
        shape: "org-node",
        attrs: {
          text: {
            text: Dom.breakText(name, { width: 105, height: 45 }),
          },
          // ".name": {
          //   text: Dom.breakText(name, { width: 105, height: 45 }),
          // },
        },
        data: {
          organizationId: id,
        }
      })
    }

    function createEdge(source: Cell, target: Cell) {
      return graph.createEdge({
        shape: "org-edge",
        source: { cell: source.id },
        target: { cell: target.id },
      })
    }

    const nodes: Node<Node.Properties>[] = []
    let organizationMap = new Map();

    this.organizationList.forEach((organization, index) => {
      //新增節點後放入nodes中
      nodes.push(createNode(organization.id, organization.name));

      //在organizationMap中設定organization.id與陣列位置的對應關係
      organizationMap.set(organization.id, index);
    })

    const edges: Edge<Edge.Properties>[] = []
    this.organizationList.forEach((organization) => {
      if (organization.upperOrganizationId == 0) {
        return;
      }
      let parentNode = organizationMap.get(organization.upperOrganizationId) as number;
      let selfNode = organizationMap.get(organization.id) as number;
      edges.push(createEdge(nodes[parentNode], nodes[selfNode]));
    })


    graph.resetCells([...nodes, ...edges])
    layout()
    graph.zoomTo(0.8)
    graph.fitToContent({ padding: 20 });
    setup()
  }
  async mounted() {
    await this.getOrganizations();
    // this.initAntvX6();
  }

  findSelfOrganizationRoute(upperOrganizationId: number | undefined | null) {
    let organization = this.organizationList.find(x => x.id == upperOrganizationId);
    let orgAry: Array<string | undefined> = [];
    orgAry.push(organization?.name);
    if (organization?.upperOrganizationId != 0) {
      let parent = this.findSelfOrganizationRoute(organization?.upperOrganizationId);
      orgAry = parent.concat(orgAry);
    }
    return orgAry;
  }
  async getOrganizations() {
    this.organizationList = (await this.apis.feature.organization.fetchOrganizations({} as FetchAllOrganizationRequest)).data;
    this.beforeEdit = this.organizationList.slice().map(x => ({ ...x }));
  }
  async putOrganizations(organization: OrganizationView) {
    await this.apis.feature.organization.putOrganization(organization as UpdateOrganizationCommand);
  }
  async createOrganization(org: OrganizationView) {
    await this.apis.feature.organization.createOrganization(org as CreateOrganizationCommand);
  }
  async confirmSave(){
    const isConfirm = await this.showConfirmDialogAsync("確定儲存修改?", "");
    if (isConfirm) this.save();
  }
  @WithLoading()
  async save() {
    this.organizationList = this.organizationList.filter(x => x.name);
    for (let org of this.organizationList) {
      const after = { ...org, parentNode: undefined, children: undefined };
      const before = this.beforeEdit.find(x => x.id == org.id);
      if (before) {
        if (Object.keys(before).some(key => String(after[key as keyof OrganizationView]) != String(before[key as keyof OrganizationView])))
          await this.putOrganizations(org);
      } else {
        await this.createOrganization(after);
      }
    }
    this.beforeEdit = this.organizationList.slice().map(x => ({ ...x }));
    this.editable = false;
  }
  async confirmCancel() {
    const isConfirm = await this.showConfirmDialogAsync("確定取消修改?", "");
    if (!isConfirm) return;
    this.editable = false;
    this.organizationList = this.beforeEdit.map(x => ({ ...x }) as Org);
  }
  async createAssociation() {
    return false;
  }
}
</script>
