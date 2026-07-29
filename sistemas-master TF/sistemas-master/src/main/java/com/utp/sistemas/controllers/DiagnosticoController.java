package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.Diagnostico;
import com.utp.sistemas.services.DiagnosticoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/diagnosticos")
public class DiagnosticoController {

    @Autowired
    private DiagnosticoService diagnosticoService;

    @PostMapping
    public Diagnostico createDiagnostico(@RequestBody Diagnostico diagnostico) {
        return diagnosticoService.createDiagnostico(diagnostico);
    }

    @GetMapping
    public List<Diagnostico> getAllDiagnosticos() {
        return diagnosticoService.getAllDiagnosticos();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Diagnostico> getDiagnosticoById(@PathVariable Integer id) {
        return diagnosticoService.getDiagnosticoById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Diagnostico> updateDiagnostico(@PathVariable Integer id, @RequestBody Diagnostico diagnosticoDetails) {
        Diagnostico updatedDiagnostico = diagnosticoService.updateDiagnostico(id, diagnosticoDetails);
        return updatedDiagnostico != null ? ResponseEntity.ok(updatedDiagnostico) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteDiagnostico(@PathVariable Integer id) {
        diagnosticoService.deleteDiagnostico(id);
        return ResponseEntity.noContent().build();
    }
}